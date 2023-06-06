$(".evs-hideable-header").click(function(){
    let type =$(this).parent().data("showanim");
    if(type=="slide"){
        $(this).next().slideToggle(500);
    }
    else if(type=="fade"){
        $(this).next().fadeToggle(500);
    }    
});








//empty check
$(".form-control:required").blur(function(){
    if($(this).val().length==0){
         $(this).addClass("evs-control-error");
         $(this).removeClass("evs-control-valid");
    }
    else {
         $(this).removeClass("evs-control-error");
         $(this).addClass("evs-control-valid");
    }
})