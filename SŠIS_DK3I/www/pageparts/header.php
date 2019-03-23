<?php
  session_start();
?>

<!doctype html>
  <html lang="en">
  <head>
      <meta http-equiv="Content-type" content="text/html; charset=utf-8" />
      <title>Zastávky IREDO</title>
      <meta name="description" content="Popisek ke stránce">
      <meta name="author" content="Ondřej Langr">
      <link rel="stylesheet" href="<?php echo ( URL . "/css/main.css");?>">
      <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.js" ></script>
      <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
      <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous">
      <script type="text/javascript" src="<?php echo (URL . "/js/points_array.js");?>"></script>
      <script src="https://api.mapy.cz/loader.js"></script>
	    <script>Loader.load()</script>
  </head>
  <body>
      <header>
        <div class="open_menu"><span onclick="openNav()"><i class="fas fa-bars"></i></span></div>
        <?php get_nav();?>
      </header>
    <div id="main-content">
