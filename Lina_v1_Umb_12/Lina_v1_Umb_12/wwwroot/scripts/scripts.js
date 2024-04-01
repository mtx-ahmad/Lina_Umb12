
(function ($) {

$(document).ready(function () {
    var mobile = (/iphone|ipod|android|blackberry|mini|windows phone|windowssce|palm/i.test(navigator.userAgent.toLowerCase()));


    //const lenis = new Lenis()
        
    // lenis.on('scroll', (e) => {
    //   console.log(e)
    // })
    
    // function raf(time) {
    //   lenis.raf(time)
    //   requestAnimationFrame(raf)
    // }
    
    // requestAnimationFrame(raf)
    
    $(window).scroll(function () {
        //if ($(this).scrollTop() > $(window).height()) {
        if ($(this).scrollTop() > 1) {
            $('body').addClass("sticky");
            if ($("body").hasClass("white")) {
                $('body').removeClass("wh");
            }
        }
        else {
            $('body').removeClass("sticky");
            if ($("body").hasClass("white")) {
                $('body').addClass("wh");
            }
        }
    });
    $(".menu").click(function () {
        if ($(this).hasClass("active")) {
            $(this).removeClass("active");
            $("body").removeClass("open-nav");

        } else {
            $(this).addClass("active");
            $("body").addClass("open-nav");
        }
    });
    
    $("header nav ul li a").click(function () {
        $('.menu').removeClass("active");
        $("body").removeClass("open-nav");
    });

    if ($(".sx").length > 0) {
        //mousewheel scroll
        const mouseWheel = document.querySelector('.sx');

        $('.sx').each(function () { 
            //alert("1");
            this.addEventListener('wheel', function (e) {
                const race = 30; // How many pixels to scroll

                // if (e.deltaY > 0){
                //     this.scrollLeft += race;
                // }
                // else {
                //     this.scrollLeft -= race;
                // }

                // if (e.deltaX > 0){ 
                //     this.scrollLeft += race;
                // }
                // else{
                //     this.scrollLeft -= race;
                // }

                if (e.deltaY > 0)
                {
                //console.log('scrolling up');
                this.scrollLeft += race;
                }
                else if (e.deltaY < 0)
                {
                //console.log('scrolling down');
                this.scrollLeft -= race;
                }
                else if (e.deltaX > 0)
                {
                //console.log('scrolling right');
                this.scrollLeft += race;
                }
                else if (e.deltaX < 0)
                {
                //console.log('scrolling left');
                this.scrollLeft -= race;
                }
                e.preventDefault();
            }); 

        
            //Drag scroll
            //const slider = document.querySelector('.home-slide-box .sx');
            let mouseDown = false;
            let startX, scrollLeft;

            let startDragging = function (e) {
                mouseDown = true;
                startX = e.pageX - this.offsetLeft;
                scrollLeft = this.scrollLeft;
            };
            let stopDragging = function (event) {
                mouseDown = false;
            };

            this.addEventListener('mousemove', (e) => {
                e.preventDefault();
                if (!mouseDown) { return; }
                const x = e.pageX - this.offsetLeft;
                const scroll = x - startX;
                this.scrollLeft = scrollLeft - scroll;
            });

            // Add the event listeners
            this.addEventListener('mousedown', startDragging, false);
            this.addEventListener('mouseup', stopDragging, false);
            this.addEventListener('mouseleave', stopDragging, false); 

        })

        var step = 5;
        var scrolling = false;
        
        $(".arrow.l").click(function(event) {
            event.preventDefault();
            // Animates the scrollTop property by the specified
            // step.
            $(".home-slide-box .sx").animate({
                scrollLeft: "-=" + step + "px"
            });
        }).mouseover(function(event) {
            scrolling = true;
            scrollContent("left");
        }).mouseout(function(event) {
            scrolling = false;
        });
    
    
        $(".arrow.r").click(function(event) {
            event.preventDefault();
            $(".home-slide-box .sx").animate({
                scrollRight: "+=" + step + "px"
            });
        }).mouseover(function(event) {
            scrolling = true;
            scrollContent("right");
        }).mouseout(function(event) {
            scrolling = false;
        });
    
        function scrollContent(direction) {        
            var amount = (direction === "left" ? "-=5px" : "+=5px");  //scroll speed
            $(".home-slide-box .sx").animate({
                scrollLeft: amount
            },1, function() {
                if (scrolling) {
                    scrollContent(direction);
                }
            });
        }
    }

    // $(".menu").click(function () {
    //     if ($("body").hasClass("open-nav")) {
    //         $("body").removeClass('open-nav');
    //     } else {
    //         $("body").addClass('open-nav');
    //     }
    // });
 
    // $("header nav ul li a").click(function () {
    //     $("body").removeClass('open-nav');
    // });

    // if ($('.slider-box').length > 0) {
    //     setTimeout(function () { 
    //         $('.slider-box').addClass("fade");
    //     }, 100);
    // }
    
    //$(window).on("load",function(){ 
    // $(".sx").mCustomScrollbar({
    //     axis: "x",
    //     mouseWheelPixels: 300,
    //     theme: "light-thin",
    //     scrollbarPosition: "inside",
    //     advanced: {
    //         autoExpandHorizontalScroll: false
    //     }
    // }); 
    //if ($('.home-slide-box').length > 0) {
        
            // $('.home-slide-box div').slick({
            //     slidesToShow: 1,
            //     //slidesToScroll: 1,
            //     infinite: false,
            //     autoplay: false,
            //     autoplaySpeed: 3000,
                
            //     variableWidth: true,
            //     dots: true,
            //     arrows:true,
            //     animate: 'slide',
            //     fade: false,
            //     speed: 1000,
            //     centerMode: true,
            //     //centerPadding: '12.5vw',
			// 	centerPadding: '0',
            //     customPaging: function (slider, i) {
            //         var thumb = $(slider.$slides[i]).data();
            //         //return '<a>' + (i + 1) + '<span>/</span>' + slider.slideCount + '</a>';
            //     },
            //     responsive: [{
            //         breakpoint: 769,
            //         settings: {
            //             variableWidth: false,
            //             centerMode: true,
            //             centerPadding: '6.666666666666667vw',
            //             autoplaySpeed: 4000
            //         }
            //     }]
            // });

            // $('.home-slide-box div').slick({
            //     dots: false,
            //     infinite: true,
            //     arrows:true,
            //     speed: 300,
            //     slidesToShow: 3,
            //     centerMode: false,
            //     variableWidth: true
            // });

        // $('.home-slide-box div').slick({
        //     slidesToShow: 1,
        //     slidesToScroll: 1,
        //     autoplay: false,
        //     variableWidth: true,
        //     infinite: false,
        //     dots: true,
        //     draggable: false,
        //     //animation: 'slide',
        //     fade: true,
        //     speed: 1000,
        //     centerMode: false,
        //     centerPadding: '0',
        //     arrows:true,
        //     pauseOnHover:false,
        //     responsive: [
        //         {
        //             breakpoint: 767,
        //             settings: {
        //                 focusOnSelect: false
        //             }
        //         }
        //     ]
        // }); 
        // $(".brouchure.sld .bgimg div").on("beforeChange", function() {
        //   $("section #content .brouchure.sld .bgimg article figure").removeClass("fxfade");
        //   $("section #content .brouchure.sld .bgimg article figure").removeClass("fadevisible");  
        // })
    //}
    if ($('.our-community-box').length > 0) {
        // $('.our-community-box .community').slick({
        //     dots: false,
        //     infinite: true,
        //     arrows:true,
        //     speed: 300, 
        //     slidesToShow: 3,
        //     centerMode: true,
        //     centerPadding: '0',
        //     variableWidth: true
        // }); 
        $('.our-community-box .community').slick({
            dots: false,
            infinite: true,
            arrows:false,
            speed: 300, 
            slidesToShow: 2,
            centerMode: true,
            centerPadding: '0',
            variableWidth: true,
            mobileFirst: true, 
            responsive: [
               {
                  breakpoint: 767,
                  settings: "unslick"
               }
            ]
         });
    }

    setTimeout(function(){   
        if (window.location.hash) {  
            $('html, body').animate({
                scrollTop: $(window.location.hash).offset().top - ($("header").height())
            }, 1000, 'swing');
        }
    }, 1500);

    var headerHeight = $("header").height();
    $(document).on("scroll", onScroll);
    //smoothscroll
    $('.scroll, .main-nav li a').on('click', function (e) {
       $(document).off("scroll");
       $('.scroll, .main-nav li a').each(function () {
           $(this).removeClass('active');
       })
       $(this).addClass('active');
       var target = this.hash, menu = target; $target = $(target);
       $('html, body').animate({ scrollTop: ($target.offset().top - ($("header").height())) }, 800, 'swing', function () {
           //window.location.hash = target;
           $(document).on("scroll", onScroll);
       });
       e.preventDefault();
    });

});

})(jQuery);

function onScroll(event) {
   var scrollPos = $(document).scrollTop();
   $('.scroll, .main-nav li a').each(function () {
       var currLink = $(this);
       var refElement = $(currLink.attr("href"));
       if (refElement.position().top <= scrollPos && refElement.position().top + refElement.height() > scrollPos) {
           $('a.scroll').removeClass("active");
           currLink.addClass("active");
       }
       else {
           currLink.removeClass("active");
       }
   });
}
