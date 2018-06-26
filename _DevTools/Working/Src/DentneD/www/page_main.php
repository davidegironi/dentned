<?php
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.

defined( '_VALID_' ) or die( 'Restricted access' );

?>

<!DOCTYPE html>
<!--[if lt IE 7 ]><html class="ie ie6" lang="en"> <![endif]-->
<!--[if IE 7 ]><html class="ie ie7" lang="en"> <![endif]-->
<!--[if IE 8 ]><html class="ie ie8" lang="en"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!--><html lang="en"> <!--<![endif]-->
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

  <title><?php echo $lang['TITLE']; ?></title>
  <meta property="og:title" content="<?php echo $lang['TITLE']; ?>" />
  <meta name="description" content="DentneD web app">
  <meta property="og:description" content="DentneD web app" />
  <meta name="author" content="Davide Gironi">
  <link rel="icon" href="favicon.ico">
  <link rel="shortcut icon" href="favicon.ico">
  <meta property="og:image" content="favicon.png" />

  <meta name="robots" content="index,follow">
  <meta name="expires" content="never"> 
  <meta name="distribution" content="global"> 
  <meta name="revisit-after" content="15 days">
  <meta name="rating" content="general">

  <!--[if lt IE 9]>
    <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
  <![endif]-->
  
  <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,400italic,600,600italic,700,700italic' rel='stylesheet' type='text/css'>

  <script src="lib/jquery/jquery-1.11.3.min.js"></script>
  <script src='lib/moment/moment.min.js'></script>

  <link href="lib/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <script src="lib/bootstrap/js/bootstrap.min.js"></script>

  <link rel='stylesheet' href='lib/fullcalendar/fullcalendar.css' />
  <script src='lib/fullcalendar/fullcalendar.js'></script>
  <script src='lib/fullcalendar/lang-all.js'></script>

  <link href="css/style.css" rel="stylesheet">
</head>
<body>
  <div id="wrap">
    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="#"><?php echo $lang['TITLE']; ?></a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
          <form class="navbar-form navbar-right" method="POST">
<?php if(!$login->isLoggedIn) { ?>
            <div class="form-group text-right">
              <input type="text" placeholder="<?php echo $lang['MENU_LOGINUSERNAME']; ?>" name="username" class="form-control">
            </div>
            <div class="form-group text-right">
              <input type="password" placeholder="<?php echo $lang['MENU_LOGINPASSWORD']; ?>" name="password" class="form-control">
            </div>
            <div class="form-group text-right">
              <label class="navbar-text checkbox inline" style="font-weight: normal;">
                <input type="checkbox" name="remindme">&nbsp;<?php echo $lang['MENU_LOGINREMINDME']; ?>
              </label>
            </div>
            <input type="hidden" value="1" name="login">
            <button type="submit" class="btn btn-success"><?php echo $lang['MENU_LOGINBUTTONIN']; ?></button>
<?php } else { ?>
            <div class="form-group text-right">
              <div class="navbar-text" style="margin-top: 0px; margin-bottom: 0px;">
                <?php echo "<b>".$lang['MENU_LOGINLOGGEDAS'] . "</b> " . $login->userName; ?>
              </div>
            </div>
            <input type="hidden" value="1" name="logout">
            <button type="submit" class="btn btn-success"><?php echo $lang['MENU_LOGINBUTTONOUT']; ?></button>
<?php } ?>
            </form>
        </div>
      </div>
    </nav>

    <div class="container">
<?php if(!empty($login->messages)) { ?>
      <div id="loginModal" class="modal fade">
          <div class="modal-dialog">
              <div class="modal-content">
                  <div class="modal-header">
                      <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                      <h4 id="loginModalTitle" class="modal-title"><?php echo $lang['LOGIN_MODALINFO']; ?></h4>
                  </div>
                  <div id="loginModalBody" class="modal-body">
                      <?php echo $login->messages; ?>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal"><?php echo $lang['LOGIN_MODALCLOSE']; ?></button>
                </div>
              </div> 
          </div>
      </div>

      <script>
        $(document).ready(function() {
          var loginModal = $('#loginModal');
          clearTimeout(loginModal.data('hideInterval'));
          loginModal.data('hideInterval', setTimeout(function(){
            loginModal.modal('hide');
          }, 2000));
          loginModal.modal('show');
        });
      </script>
<?php } ?>

<?php if(!$login->isLoggedIn) { ?>
      <?php echo $lang['LOGIN_MESSAGE']; ?>
<?php } else { ?>
      <div id='calendar'></div>
      <br/><br/>

      <div id="fullCalModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h4 id="fullCalModalTitle" class="modal-title"></h4>
                </div>
                <div id="fullCalModalBody" class="modal-body"></div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal"><?php echo $lang['MODALEVENT_CLOSE']; ?></button>
                </div>
            </div>
        </div>
      </div>

      <script>
        $(document).ready(function() {
          function get_calendar_height() {
            return $(window).height() - 150;
          }
          $(window).resize(function() {
            $('#calendar').fullCalendar('option', 'height', get_calendar_height());
          });
          $('#calendar').fullCalendar({
            header: { 
              left: 'prev,next today',
              center: 'title',
              right: 'month,agendaWeek,agendaDay'
            },
            height: get_calendar_height(),
            editable: false,
            lang: '<?php echo $language;?>',
            events: 'index.php?ajax=1&f=events',
            defaultView: '<?php echo $calendarStartPage; ?>',
            scrollTime: '<?php echo $calendarScrollTime; ?>',
            eventClick: function(calEvent, jsEvent, view) {
              $('#fullCalModalTitle').html(calEvent.title);
              $('#fullCalModalBody').html(calEvent.description);
              $('#fullCalModal').modal();
            }
          });
        });
      </script>
<?php } ?>
  
      <div id="push"></div>

    </div>
  </div>

  <div id="footer">
    <div class="container">
      <p class="muted credit">Powered by <a href="https://github.com/davidegironi/dentned"><b>DentneD</b></a>.</p>
    </div>
  </div>

</body>
</html>
