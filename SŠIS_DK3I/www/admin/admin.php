<!-- Call for builder -->
<?php require ($_SERVER['DOCUMENT_ROOT'] . 'constructor.php');?>
<?php
  get_header();
  if( ! is_user_logged_in()){header("location: " . LOGINURL);exit;}
?>
<!-- CONTENT START -->
    <div class="col-12 admin_panel row">
      <div class="col-lg-4 left_side_panel overflow-hidden">
        <div class="card overflow-auto">
          <div class="card-body">
            <h5 class="card-title">Vítejte, <?php echo htmlspecialchars($_SESSION["username"]); ?>!</h5>
            <p class="card-text">Vítejte v panelu administrace pro <span style="color: green"><?php echo ltrim(URL, "http://");?>.</span>.</p>
          </div>
          <ul class="list-group list-group-flush">
            <li class="list-group-item"><a onclick="loadSettingsParts('upravit_zastavky')">Upravit zastávky</a></li>
            <li class="list-group-item"><a onclick="loadSettingsParts('pridat_uzivatele')">Přidat uživatele</a></li>
          </ul>
          <div class="card-body">
            <a href="<?php echo (LOGOUTURL);?>"class="btn btn-danger">Odhlásit se</a>
            <a onclick="loadSettingsParts('zmenit_heslo')" class="btn btn-secondary btn-sm">Změnit heslo</a>
          </div>
        </div>
      </div>
      <div class="col-lg-8 right_side_panel overflow-hidden">
        <div id="sett_admin_panel" class="card overflow-auto h-100">
          <?php
            $pagelink = $_GET['p'];
            if ($pagelink != ""){ //check for data in url if so, load settings ?>
              <iframe src="<?php echo (URL . '/admin/' . $pagelink . ".php");?>" style="height: 100%;border: none;"></iframe>
          <?php }?>
        </div>
      </div>
    </div>
    <link rel="stylesheet" href="<?php echo ( URL . "/css/admin.css");?>">
    <script>
      function loadSettingsParts(page){
        $("#sett_admin_panel").html('<iframe src="<?php echo (URL . '/admin/');?>' + page + '.php' + '" style="height: 100%;border: none;"></iframe>');
      }
      $(document).ready(function(){
            var uri = window.location.toString();
            if (uri.indexOf("?") > 0) {
            	    var clean_uri = uri.substring(0, uri.indexOf("?"));
            	    window.history.replaceState({}, document.title, clean_uri);
	           }
          });
    </script>
<!-- CONTENT END -->
<!-- Call for footer -->
<?php get_footer(); ?>
