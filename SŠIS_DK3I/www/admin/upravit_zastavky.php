<?php
  require_once ($_SERVER['DOCUMENT_ROOT'] . 'constructor.php');
  get_sett_header();
  if( ! is_user_logged_in()){header("location: ". LOGINURL);exit;}
  require_once (REL_CESTA . "db_conn.php");
?>

<?php
  $alerts = "";
  if( ! is_user_logged_in()){header("location: " . LOGINURL);exit;}
  if(isset($_POST["Import"])) {
    $target_dir = REL_CESTA . "data/temp/";
    $target_file = $target_dir . basename($_FILES["file"]["name"]);
    $imageFileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION));
    $array_of_points = fopen(REL_CESTA . 'js/points_array.js', 'w');
    if ( ! file_exists($target_file)) {
      if ( ! ($_FILES["file"]["size"] > 500000000)) {
        if($imageFileType != "csv" ) {
            $alerts =  "Omlouváme se, pouze csv či excel soubory jsou povoleny.";
        }
        else {
          if (sizeof(scandir($target_dir)) === 3){
            unlink(($target_dir . scandir($target_dir)[2]));
          }
          if (move_uploaded_file($_FILES["file"]["tmp_name"], $target_file)) {
              if (($handle = fopen($target_file, "r")) !== FALSE) {
                  fwrite($array_of_points, "var data = [");
                  $name_old;
                  while (($data = fgetcsv($handle, 1000, ",")) !== FALSE) {

                    if ($row > 1) {
                      if ($data[6] !== $name_old) {
                        $coords = $data[0];
                        $coords = str_replace("POINT (", "", $coords);
                        $coords = explode(" ", str_replace(")", "", $coords));
                        if ($row===2){
                          fwrite($array_of_points, '["' .  $data[6]. '", "' . $coords[0] . '", "' . $coords[1] . '"]');
                        }
                        else {
                          fwrite($array_of_points, ', ["' .  $data[6]  . '", "' . $coords[0] . '", "' . $coords[1] . '"]');
                        }
                      }
                      $name_old = $data[6];
                    }
                    $row++;
                  }
                fwrite($array_of_points, "\n]");
                fclose($handle);
                fclose($array_of_points);
              }
              $alerts = "Soubor s názvem: ". basename( $_FILES["file"]["name"]). " byl uložen.";
          } else {
              $alerts = "Omlouváme se, stala se chyba. Zkuste to prosm znovu.";
          }
        }
      }
      else {
        $alerts = "Tento soubor je moc velký!";
      }
    }
    else {
      $alerts =  "Tento soubor už existuje";
    }

  }
?>
<div class="position-relative bg-white w-100" style="float: left;height: 50vh;  background: white;">
  <h2>Upravení zástávek</h2>
  <small>Pro úpravu prosím nahrajte soubor EXCELU či CSV</small>
  <form enctype="multipart/form-data" method="post" role="form" style="padding: 30px 0px 0px 20px;">
      <div class="form-group">
          <label for="exampleInputFile">Nahrát soubor </label>
          <input type="file" name="file" id="file" size="150">
          <p class="help-block"><small><?php echo $alerts;?></small></p>
      </div>
      <button type="submit" class="btn btn-default" name="Import" value="Import">Upload</button>
  </form>
</div>
<div style="    overflow-y: auto;height: 50vh;width: 100%;">

  </div>
<?php get_sett_footer();?>
