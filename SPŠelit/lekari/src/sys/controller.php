<?php

class Controller {

    public function __construct() {
        $this->load     = $this;
        $this->language = new Language;
        $this->fs       = new FileSystem;
        $this->url      = new Url;
    }

    public static function display(string $viewName, array $viewData = []) {
        if(isset($_POST['command_subm']))
            return;

        foreach(array_keys($viewData) as $key) {
            $$key = $viewData[$key];
        }

        $_url = $_GET['vars'];

        $viewPath = VIEWS . $_SESSION['theme'] . "/templates/$viewName.view.php";

        if(file_exists($viewPath)) {            
            if(!empty($GLOBALS['styles']))
                foreach($GLOBALS['styles'] as $key => $path) {
                    # Include style
                    echo "<link rel='stylesheet' href='$path'>";
                    # Unload style
                    unset($GLOBALS['styles'][$key]);
                }

            if(!empty($GLOBALS['scripts']))
                foreach($GLOBALS['scripts'] as $key => $path) {
                    # Include script
                    echo "<script src='$path'></script>";
                    # Unload script
                    unset($GLOBALS['scripts'][$key]);
                }

            include $viewPath;
        }

        else
            exit("View $viewName does not exist!");
    }

    public function style($path) {
        array_push($GLOBALS['styles'], ROOT . "public/views/themes/" . $_SESSION['theme'] . "/assets/css/$path.css");
        array_push($GLOBALS['styles_archive'], ROOT . "public/views/themes/" . $_SESSION['theme'] . "/assets/css/$path.css");
    }

    public function script($path) {
        array_push($GLOBALS['scripts'], ROOT . "public/views/scripts/$path.js");
        array_push($GLOBALS['scripts_archive'], ROOT . "public/views/scripts/$path.js");
    }

    public static function controller($path) {
        require_once CONTROLLERS . "/$path.controller.php";

        $className = "Controller" . implode("", explode("/", $path));
        $class = new $className;

        $class->index();
    }

    public static function model($path) {
        require_once MODELS . "/$path.model.php";

        $className = "Model" . implode("", explode("/", $path));
        $class = new $className;

        return $class;
    }

    public static function view($path) {
        ob_start();
            self::controller($path);
        
        return ob_get_clean();
    }

    public static function language($path) {
        include_once LANGUAGE . $_SESSION['language'] . "/" . $path . ".lang.php";

        return @$language;
    }

    public static function init() {
        self::controller($_GET['url']);
    }

}