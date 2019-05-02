$(document).ready(function () {
  
  $('#get-weather-button').click(function(event){

  var haveValidationErrors = checkAndDisplayValidationErrors($('#get-weather-form').find('input'));

  if (haveValidationErrors) {
      return false;
  }

  var zipcode = document.getElementById("zipcode");
  var strZipcode = zipcode.value;

  $('#weather-info').show();
  
  $.ajax({
            type: 'GET',
            url: 'http://api.openweathermap.org/data/2.5/forecast?zip=' + strZipcode + ',us&APPID=050b92d99de12dc2682f6d557fb77ebd', 
            success: function(data, status) {
                // clear errorMessages
                $('#errorMessages').empty();
               // Clear the form and reload the table

                var currentWeatherTemp = data.list[0].main.temp;
                var currentWeatherHumidity = data.list[0].main.humidity + "%";
                var currentWeatherWind = data.list[0].wind.speed;
                var currentWeatherImage = data.list[0].weather[0].icon;
                var currentWeatherInfo = data.list[0].weather[0].description;
                var currentWeatherCity = data.city.name;
                var tempScale = document.getElementById("search-dropdown");
                var sTempScale = tempScale.options[tempScale.selectedIndex].value;
                var temp;

                if(sTempScale == "Imperial")
                {
                  currentWeatherTemp = Imperial(currentWeatherTemp);
                  temp = "F";
                }

                else
                {
                  currentWeatherTemp = Metric(currentWeatherTemp);
                  temp = "C";
                }
                var i;
                for (i = 0; i < 33; i+=8) { 
                  var fiveDayDate = getDate(data.list[i].dt_txt);
                  var fiveDayConditionsDescription = data.list[i].weather[0].description;
                  var fiveDayConditionsImage = data.list[i].weather[0].icon;
                  var fiveDayHigh = data.list[i].main.temp_max;
                  var fiveDayLow = data.list[i].main.temp_min;

                if(sTempScale == "Imperial")
                {
                  fiveDayHigh = Imperial(fiveDayHigh);
                  fiveDayLow = Imperial(fiveDayLow);
                }

                else
                {
                  fiveDayHigh = Metric(fiveDayHigh);
                  fiveDayLow = Metric(fiveDayLow);
                }

                var fiveDayAppend = '<p>'+ fiveDayDate + '</p> <p> <img src="http://openweathermap.org/img/w/' + fiveDayConditionsImage + '.png" /> ' + fiveDayConditionsDescription + '<p> H ' + fiveDayHigh + ' ' + temp + ' L ' + fiveDayLow + ' ' + temp + '</p>';

                  //some function to convert the kelvin to C or F
                  switch (i) {
                      case 0:
                      $('#five-day-1').append($(fiveDayAppend));
                        break;
                      case 8:
                      $('#five-day-2').append($(fiveDayAppend));
                        break;
                      case 16:
                      $('#five-day-3').append($(fiveDayAppend));
                        break;
                      case 24:
                      $('#five-day-4').append($(fiveDayAppend));
                        break;
                      case 32:
                      $('#five-day-5').append($(fiveDayAppend));
                    }
                  //$('#five-day-1').append($('<p>'+ fiveDayDate + '</p> <p> <img src="http://openweathermap.org/img/w/' + fiveDayConditionsImage + '.png" /> ' + fiveDayConditionsDescription + '<p> H ' + fiveDayHigh + ' ' + temp + ' L' + fiveDayLow + ' ' + temp + '</p>'));

                }

                $('#current-weather-city').append(currentWeatherCity);
                $('#current-weather-image').append($('<img src="http://openweathermap.org/img/w/' + currentWeatherImage + '.png" />' ));
                $('#current-weather-info').append(currentWeatherInfo);
                $('#current-weather-temp').append(currentWeatherTemp + ' ' + temp);
                $('#current-weather-humidity').append(currentWeatherHumidity);
                $('#current-weather-wind').append(currentWeatherWind + " miles/hour");
            },
            error: function() {
                $('#errorMessages')
                   .append($('<li>')
                   .attr({class: 'list-group-item list-group-item-danger'})
                   .text('Error calling web service.  Please try again later.'));
            }
        });

  });
});

function checkAndDisplayValidationErrors(input) {
    // clear displayed error message if there are any
    $('#errorMessages').empty();
    // check for HTML5 validation errors and process/display appropriately
    // a place to hold error messages
    var errorMessages = [];

    // loop through each input and check for validation errors
    input.each(function() {
        // Use the HTML5 validation API to find the validation errors
        if(!this.validity.valid)
        {
            var errorField = $('label[for='+this.id+']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    // put any error messages in the errorMessages div
    if (errorMessages.length > 0){
        $.each(errorMessages,function(index,message){
            $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text(message));
        });
        // return true, indicating that there were errors
        return true;
    } else {
        // return false, indicating that there were no errors
        return false;
    }
}

function Imperial(temp){
  var imperialTemp = Math.round((temp - 273.15) * (9/5) + 32);
  return imperialTemp;
}

function Metric(temp){
  var metricTemp = Math.round(temp - 273.15);

  return metricTemp
}

function getDate(date){
  var month = date.substring(5,7);
  var day = date.substring(8,10);

  switch (month) {
                      case "01":
                      month = "January"
                        break;
                      case "02":
                      month = "February"
                        break;
                      case "03":
                      month = "March"
                        break;
                      case "04":
                      month = "April"
                        break;
                      case "05":
                      month = "May"
                        break;
                      case "06":
                      month = "June"
                        break;
                      case "07":
                      month = "July"
                        break;
                      case "08":
                      month = "August"
                        break;                                                
                      case "09":
                      month = "September"
                        break;
                      case "10":
                      month = "October"
                        break;
                      case "11":
                      month = "November"
                        break;
                      case "12":
                      month = "December"
                  }

      var date = month + " " + day;
      return date;
}
