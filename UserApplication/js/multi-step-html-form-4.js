/*
|--------------------------------------------------------------------------
| QuoteForm Template Main JS
|--------------------------------------------------------------------------
*/
document.addEventListener("touchstart", function() {},false);
(function ($) {
	"use strict";
	
/*
|--------------------------------------------------------------------------
	Print Current Year in html footer copyright
|--------------------------------------------------------------------------
*/
	$('span#mgsYear').html( new Date().getFullYear() );
	
/*
|--------------------------------------------------------------------------
| Bootstrap embedded Datepicker
|--------------------------------------------------------------------------
*/	
	$(function(){
	
		$('#datepicker').datepicker();
		$('#datepicker').on('changeDate', function() {
			$('#launchdate').val(
				$('#datepicker').datepicker('getFormattedDate')
			);
		});
	 
	});

/*
|--------------------------------------------------------------------------
| QuoteForm
|--------------------------------------------------------------------------
*/
	
	$("#QuoteForm").validator().on("submit", function (event) {
		if (event.isDefaultPrevented()) {
			//handle the invalid form...
			formError();
			submitMSG(false, "Please fill in the form properly!");
		} else {
			//everything looks good!
			event.preventDefault();
			submitForm();
		}
	});
	
	function submitForm(){
		
		//process your form here.
		$( "#mgsContactSubmit" ).html( '' );
		$( "#final-step-buttons" ).html( '<div class="h3 text-center text-success"> You have finished all steps of this html form successfully!!! </div>' );
		swal("Good job!", "You have finished all steps of this html form successfully!!!", "success");
		
	}
	
	//attachment
	$(function() {

		$(document).on('change', ':file', function() {
			var input = $(this),
				numFiles = input.get(0).files ? input.get(0).files.length : 1,
				label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
			input.trigger('fileselect', [numFiles, label]);
		});

		$(':file').on('fileselect', function(event, numFiles, label) {

			var input = $(this).parents('.form-group').find(':text'),
				log = numFiles > 1 ? numFiles + ' files selected' : label;

			if( input.length ) {
				input.val(log);
			} else {
				if( log ) alert(log);
			}

		});
	  
	});
		
	function formSuccess(){
		$("#QuoteForm")[0].reset();
		submitMSG(true, "Your Message Submitted Successfully!")
	}
	
	function formError(){
		$(".help-block.with-errors").removeClass('hidden');
	}
	
	function submitMSG(valid, msg){
		if(valid){
			var msgClasses = "h3 text-center text-success";
			$( "#final-step-buttons" ).html( '<div class="h3 text-center text-success"> Thank you for your concern. We will get back to you soon!</div>' );
		} else {
			var msgClasses = "h3 text-center text-danger";
		}
		$("#mgsContactSubmit").removeClass().addClass(msgClasses).text(msg);
	}

})(jQuery);	
	
/*
|--------------------------------------------------------------------------
| overly
|--------------------------------------------------------------------------
*/	
		
	function isEmail(email) {
		var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
		return regex.test(email);
	}
	
	function nextStep2() {
		
		var opsys = $('input[name=opsys]:checked').val();
		var reqsevice = $("#reqsevice").val();
		var reqfeatures = $("#reqfeatures").val();
		
		if( opsys )
			$( ".validopsys .help-block.with-errors" ).html( '' );
		else
			$( ".validopsys .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please Select OS</li></ul>' );
		
		if( reqsevice )
			$( ".validreqsevice .help-block.with-errors" ).html( '' );
		else
			$( ".validreqsevice .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please Select Service</li></ul>' );
		
		if( reqfeatures != "" )
			$( ".validreqfeatures .help-block.with-errors" ).html( '' );
		else
			$( ".validreqfeatures .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please Select Features</li></ul>' );
		
		if( opsys && reqsevice && reqfeatures != "" ) {
			$( "#section-1 .help-block.with-errors" ).html( '' );
			$( "#section-1" ).removeClass( "open" );
			$( "#section-1" ).addClass( "slide-left" );
			$( "#section-2" ).removeClass( "slide-right" );
			$( "#section-2" ).addClass( "open" );
		}
		else {
			$( "#section-1 .help-block.with-errors.mandatory-error" ).html( '<ul class="list-unstyled"><li>Please Fill the Form Properly</li></ul>' );
		}
		
	}
	function previousStep1() {
		$( "#section-1" ).removeClass( "slide-left" );
		$( "#section-1" ).addClass( "open" );
		$( "#section-2" ).removeClass( "open" );
		$( "#section-2" ).addClass( "slide-right" );
	}
	
	function nextStep3() {
		
		var probudget = $("#probudget").val();
		var priority = $('input[name=priority]:checked').val();
		var launchdate = $("#launchdate").val();
		
		if( probudget )
			$( ".validprobudget .help-block.with-errors" ).html( '' );
		else
			$( ".validprobudget .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please Select Budget</li></ul>' );
		
		if( priority )
			$( ".validpriority .help-block.with-errors" ).html( '' );
		else
			$( ".validpriority .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please Select Priority</li></ul>' );
		
		if( launchdate )
			$( ".validlaunchdate .help-block.with-errors" ).html( '' );
		else
			$( ".validlaunchdate .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please Select Launch Date</li></ul>' );
		
		if( probudget && priority && launchdate ) {
			$( "#section-2 .help-block.with-errors.mandatory-error" ).html( '' );
			$( "#section-2" ).removeClass( "open" );
			$( "#section-2" ).addClass( "slide-left" );
			$( "#section-3" ).removeClass( "slide-right" );
			$( "#section-3" ).addClass( "open" );
		}
		else {
			$( "#section-2 .help-block.with-errors.mandatory-error" ).html( '<ul class="list-unstyled"><li>Please Fill the Form Properly</li></ul>' );
		}
		
	}
	function previousStep2() {
		$( "#section-2" ).removeClass( "slide-left" );
		$( "#section-2" ).addClass( "open" );
		$( "#section-3" ).removeClass( "open" );
		$( "#section-3" ).addClass( "slide-right" );
	}	
	function nextStep4() {
		
		var fname = $("#fname").val();
		var lname = $("#lname").val();
		var gender = $("#gender").val();
		var address = $("#address").val();
		var email = $("#email").val();
		var phone = $("#phone").val();
		var validemail = isEmail(email);
		
		if( fname )
			$( ".validfname .help-block.with-errors" ).html( '' );
		else
			$( ".validfname .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please enter First Name</li></ul>' );
		
		if( lname )
			$( ".validlname .help-block.with-errors" ).html( '' );
		else
			$( ".validlname .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please enter Last Name</li></ul>' );
		
		if( gender )
			$( ".validgender .help-block.with-errors" ).html( '' );
		else
			$( ".validgender .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please Select Gender</li></ul>' );
		
		if( address )
			$( ".validaddress .help-block.with-errors" ).html( '' );
		else
			$( ".validaddress .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please enter Address</li></ul>' );
		
		if( validemail )
			$( ".validemail .help-block.with-errors" ).html( '' );
		else	
			$( ".validemail .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please enter valid email</li></ul>' );
		
		var filter = /^((\+[1-9]{1,4}[ \-]*)|(\([0-9]{2,3}\)[ \-]*)|([0-9]{2,4})[ \-]*)*?[0-9]{3,4}?[ \-]*[0-9]{3,4}?$/;
		if (filter.test(phone)) {
			$( ".validphone .help-block.with-errors" ).html( '' );
			var validphone = 1;
		}
		else{
			$( ".validphone .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please enter valid Phone</li></ul>' );
			var validphone = 0;
		}
		
		if( fname.length > 0 && fname && lname.length > 0 && lname && gender && address.length > 0 && address && validemail && phone.length > 4 && validphone > 0 ) {
			$( "#section-3 .help-block.with-errors.mandatory-error" ).html( '' );
			$( "#section-3" ).removeClass( "open" );
			$( "#section-3" ).addClass( "slide-left" );
			$( "#section-4" ).removeClass( "slide-right" );
			$( "#section-4" ).addClass( "open" );
		}
		else {
			$( "#section-3 .help-block.with-errors.mandatory-error" ).html( '<ul class="list-unstyled"><li>Please Fill the Form Properly</li></ul>' );
		}
		
	}	
	function previousStep3() {
		$( "#section-3" ).removeClass( "slide-left" );
		$( "#section-3" ).addClass( "open" );
		$( "#section-4" ).removeClass( "open" );
		$( "#section-4" ).addClass( "slide-right" );
	}	
	function nextStep5() {
		
		//inputed value
		var opsys = $('input[name=opsys]:checked').val();
		var reqsevice = $("#reqsevice").val();
		var reqfeatures = $("#reqfeatures").val();
		var probudget = $("#probudget").val();
		var priority = $('input[name=priority]:checked').val();
		var launchdate = $("#launchdate").val();
		var fname = $("#fname").val();
		var lname = $("#lname").val();
		var gender = $("#gender").val();
		var address = $("#address").val();
		var email = $("#email").val();
		var phone = $("#phone").val();
		var attachedFile = $("#attachedFile").val();
		var requirementdetails = $("#requirementdetails").val().replace(/\n/g,"<br>");
		var additionalinfo = $("#additionalinfo").val().replace(/\n/g,"<br>");
		var preferedcontact = $('input[name=preferedcontact]:checked').val();
		
		//write inputed data
		$( "#osData" ).html( '<strong>Selected OS:</strong> '+ opsys );
		$( "#serviceData" ).html( '<strong>Selected Service:</strong> '+ reqsevice );
		$( "#reqfeaturesData" ).html( '<strong>Selected Features:</strong> '+ reqfeatures );
		$( "#probudgetData" ).html( '<strong>Project Budget:</strong> '+ probudget );
		$( "#priorityData" ).html( '<strong>priority:</strong> '+ priority );
		$( "#launchdateData" ).html( '<strong>Estimated Launch Date:</strong> '+ launchdate );
		$( "#firstNameData" ).html( '<strong>First Name:</strong> '+ fname );
		$( "#lastNameData" ).html( '<strong>Last Name:</strong> '+ lname );
		$( "#genderData" ).html( '<strong>Gender:</strong> '+ gender );
		$( "#addressData" ).html( '<strong>Address:</strong> '+ address );
		$( "#emailaddressData" ).html( '<strong>email:</strong> '+ email );
		$( "#phoneData" ).html( '<strong>Phone:</strong> '+ phone );
		$( "#requirementdetailsData" ).html( '<strong>Requirement Details:</strong><br> '+ requirementdetails );
		$( "#additionalinfoData" ).html( '<strong>Additional Info:</strong><br> '+ additionalinfo );
		$( "#preferedcontactData" ).html( '<strong>Prefered Contact Method:</strong> '+ preferedcontact );
		
		if( preferedcontact )
			$( ".validpreferedcontact .help-block.with-errors" ).html( '' );
		else
			$( ".validpreferedcontact .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please Select Prefered Contact Method</li></ul>' );
		
		if( requirementdetails.length > 0 && requirementdetails )
			$( ".validreqdetails .help-block.with-errors" ).html( '' );
		else
			$( ".validreqdetails .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please Provide Requirement Details</li></ul>' );
		
		if( $('#aggre').is(":checked") )
			$( ".validagree .help-block.with-errors" ).html( '' );
		else
			$( ".validagree .help-block.with-errors" ).html( '<ul class="list-unstyled"><li>Please Aggre with terms &amp; conditions</li></ul>' );
			
		if (preferedcontact && requirementdetails.length > 0 && requirementdetails && $('#aggre').is(":checked")) {
			$( "#section-4 .help-block.with-errors.mandatory-error" ).html( '' );
			$( "#section-4" ).removeClass( "open" );
			$( "#section-4" ).addClass( "slide-left" );
			$( "#section-5" ).removeClass( "slide-right" );
			$( "#section-5" ).addClass( "open" );
		}
		else {
			$( "#section-4 .help-block.with-errors.mandatory-error" ).html( '<ul class="list-unstyled"><li>Please Fill the Form Properly</li></ul>' );
		}
		
	}	
	function previousStep4() {
		$( "#section-4" ).removeClass( "slide-left" );
		$( "#section-4" ).addClass( "open" );
		$( "#section-5" ).removeClass( "open" );
		$( "#section-5" ).addClass( "slide-right" );
	}
/*
|--------------------------------------------------------------------------
| End
|--------------------------------------------------------------------------
*/