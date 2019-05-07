$(document).ready(function(){

	var total = 0;	
	getVendingMachineData();

	document.getElementById('total-amount').value=total;
	document.getElementById('make-purchase-id').value=""; 
	document.getElementById('message-result').value=""; 	
	document.getElementById('change-return').value="";

	var g = document.getElementById('vendingDiv');
	var q = 0;
	for (var i = 0, len = g.children.length; i < len; i++)
	{
		for(var j = 0; j < 3; j++)
		{
			q++;
			(function(index){
	        g.children[i].children[j].onclick = function(){
     			              ;
     		document.getElementById('make-purchase-id').value=index;
     }    
	    })(q);
		}

	}

	$('.add-button').click(function(){
	   total = parseFloat(Math.round((Number(total) + Number($(this).val()))*100)/100).toFixed(2);
	   document.getElementById('total-amount').value=total;        
	});

	$('.make-purchase-button').click(function(){
		
		var id = $('#make-purchase-id').val();
		$.ajax({
            type: 'GET',
            url: 'http://localhost:8080/money/'+ total + '/item/'+ id, 
            success: function(data, status) {
			document.getElementById('message-result').value = "THANK YOU!!!"

			var coinInfo = ""; 

				if(data.quarters != 0)
				{
					coinInfo = data.quarters + " Quarter";
					if(data.quarters > 1)
						coinInfo+="s";
				}
				if(data.dimes != 0)
				{
					coinInfo += " " + data.dimes + " Dime";
					if(data.dimes > 1)
						coinInfo+="s";					
				}
				if(data.nickels != 0)
				{
					coinInfo += " " + data.nickels + " Nickel";
					if(data.nickels > 1)
						coinInfo+="s";
				}	
				if(data.pennies != 0)
				{
					coinInfo += " " + data.pennies + " Pennies";
				}										

				if(coinInfo == "")
				{
					coinInfo = "Exact change was given. No change to return.";
				}
				document.getElementById('change-return').value = coinInfo;
				document.getElementById('total-amount').value=0;
				total=0;
				getVendingMachineData();


             },
            error: function(data, status) {
            	var errorMessage = data.responseJSON.message;
            	if(data.responseJSON.message == 'No message available')
            		errorMessage = "Please select an item";
            	document.getElementById('message-result').value = errorMessage;

			}
            })
		});

		$('.make-change-button').click(function(){

			    var quarters = Math.floor(total/.25);
			    total = (total - (.25*quarters)).toFixed(2);
			    var dimes = Math.floor(total/.10);
			    total = (total - (.10*dimes)).toFixed(2);
			    var nickels = Math.floor(total/.05);
			    total = (total - (.05*nickels)).toFixed(2);
			    var pennies = total;


    			var coinInfo = ""; 

				if(quarters != 0)
				{
					coinInfo = quarters + " Quarter";
					if(quarters > 1)
						coinInfo+="s";
				}
				if(dimes != 0)
				{
					coinInfo += " " + dimes + " Dime";
					if(dimes > 1)
						coinInfo+="s";					
				}
				if(nickels != 0)
				{
					coinInfo += " " + nickels + " Nickel";
					if(nickels > 1)
						coinInfo+="s";
				}	

				document.getElementById('change-return').value = coinInfo;
				document.getElementById('total-amount').value=0;
				document.getElementById('make-purchase-id').value=""; 
				document.getElementById('message-result').value=""; 
	});

	})


function addS(coinInfo){

}
function getVendingMachineData(){
	$.ajax({
            type: 'GET',
            url: 'http://localhost:8080/items', 
            success: function(data, status) {
                // clear errorMessages
                $('#errorMessages').empty();
               // Clear the form and reload the table

               	$.each(data, function(index, snack) {
	                var snackInfo = '<p class="number">' + data[index].id + '</p><p class="name">' + data[index].name + '</p><p class="price"> $' + data[index].price + '</p><br/><p class="quantity">quantity left: ' + data[index].quantity + '</p>';
	                var gridId = '#grid-' + data[index].id;

	                $(gridId).empty();
	                $(gridId).append(snackInfo);
            	})

             },
            error: function() {
                $('#errorMessages')
                   .append($('<li>')
                   .attr({class: 'list-group-item list-group-item-danger'})
                   .text('Error calling web service.  Please try again later.'));
            }
        });
}