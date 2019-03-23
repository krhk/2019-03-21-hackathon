<!-- Call for builder -->
<?php require 'constructor.php';?>
<?php get_header();
?>
<!-- CONTENT START -->
<div class="parallax position-relative">
  <div class="filter w-100 h-100 position-absolute">
   </div>
   <div class="h1text text-center w-100">
     <h1 class="">Seznam zastávek IREDO </h1>
   </div>
</div>

<div class="zastavky">
  <table>
      <thead>
        <tr>
          <th><b>Název</b></th>
          <th><b>CRZ</b></th>
          <th style="padding-right:40px;"><b>CRZ označník</b></th>
          <th><b>Souřadnice</b></th>

        </tr>

      </thead>

      <tbody>

          <?php
          $temp_file = REL_CESTA . "data/temp/";
          if (sizeof(scandir($temp_file)) === 3){
              $target_file = $temp_file . scandir($temp_file)[2];
              $row = 1;
              $name_old;
              if (($handle = fopen($target_file, "r")) !== FALSE) {
                  while (($data = fgetcsv($handle, 1000, ",")) !== FALSE) {
                    if ($row > 1) {
                        if ($data[6] !== $name_old) {?>
                        <tr>
                          <th><?php echo ($data[6]);?></th>
                          <td><?php echo ($data[2]);?></td>
                          <td><?php echo ($data[5]);?></td>
                          <?php
                            $coords = str_replace("POINT (", "", $data[0]);
                            $coords = explode(" ", str_replace(")", "", $coords));
                          ?>
                          <td><?php echo ($coords[0] . " " . $coords[1]);?></td>
                        </tr>
                    <?php  } $name_old = $data[6]; }
                      $row++;

                    }

                  }
                fclose($handle);
              }

        ?>
    </tbody>
  </table>
</div>

<!-- CONTENT END -->
<!-- Call for footer -->
<?php get_footer(); ?>
