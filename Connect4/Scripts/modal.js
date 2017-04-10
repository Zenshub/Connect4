$(function() {
    $("#restart").click(function(event){
    $.ajax({
            url: 'Home/Restart',
            datatype: 'json',
            type: 'POST',
            data: { 
            		row: $("#rownumber").val(), 
            		column:$("#columnnumber").val() 
        		},
            success: function(){ 
            	window.location.assign("Home/Index");
            },
            error: function () {
                alert("error");
            }
        });
        return false;
    });
});

$(document).ready(function(){
	var containerWidth = $('#app').width();
	var colummNumber = $('#columnnumber').val();
	var colWidth = containerWidth/colummNumber;

	$('.connect4-column').css("width", colWidth + "px");
	$('.connect4-cell').css("width",  (colWidth -20)+"px");
	$('.connect4-cell').css("height",  (colWidth -20)+"px");

});


