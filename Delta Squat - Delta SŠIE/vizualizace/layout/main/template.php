<!DOCTYPE HTML>
<html>
    <head>
        <base href="/">
        
        <meta http-equiv="content-type" content="text/html; charset=utf-8">
        <meta name="viewport" content="width=device-width,initial-scale=1">
        
        <link href='layout/main/style.css' rel='stylesheet'>
        <link href='layout/main.css' rel='stylesheet'>
        <link href='layout/animate.css' rel='stylesheet'>
        <link href="https://fonts.googleapis.com/css?family=Baloo" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css?family=Raleway:100,300,400,700,900" rel="stylesheet">

        <script src="https://unpkg.com/popper.js@1/dist/umd/popper.min.js"></script>
        <script src="https://unpkg.com/tippy.js@4"></script>
        
        
        <title><?= $settings['MainTitle']; ?> | <?= $connection->pageTitle; ?></title>
    </head>
    <body>
        <?php
            include $connection->file;
        ?>
        <script>
            tippy('.tip')
        </script>
    </body>
</html>
