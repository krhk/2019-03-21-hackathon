<?php
session_start();

require_once("config/config.php");

if(!isset($_SESSION['theme']))
    $_SESSION['theme'] = DEFAULT_THEME;

if(!isset($_SESSION['language']))
    $_SESSION['language'] = DEFAULT_LANGUAGE;

# When trying to access root ( / ), url is not defined, define it
if(!isset($_GET['url']))
    $_GET['url'] = HOMEPAGE;

# Remove unnecessary slashes
$_GET['url'] = rtrim($_GET['url'], "/");

# Require routes array
require_once("routes.php");

foreach($GLOBALS['routes'] as $i => $route) {
    if(strpos($i, ":") === false) {
        $GLOBALS['routes'][$i] = ["route" => $route];
        continue;
    }
    
    # Split URLs into arrays
    $routes_keys = explode("/", $i);
    $url_keys = explode("/", $_GET['url']);

    # Initialize final name with the first route key
    $final_name = $routes_keys[0];

    # Compose the final name
    foreach($routes_keys as $j => $var) {
        if($j == 0)
            continue;
        
        if(strpos($var, ":") !== false) {
            if(!isset($url_keys[$j]))
                continue;

            $final_name .= "/" . $url_keys[$j];
        }

        else
            $final_name .= "/" . $var;
    }

    # Assign URL variables
    foreach($routes_keys as $k => $var) {
        if(!isset($url_keys[$k])) {
            if(strpos($var, "*") !== false && $routes_keys[0] == $_GET['url'])
                exit(ERR_NOT_FOUND);

            $GLOBALS['routes'][$final_name]['vars'][str_replace("*", "", $var)] = null;
            continue;
        }

        if(strpos($var, ":") !== false) {
            $GLOBALS['routes'][$final_name]['vars'][str_replace("*", "", $var)] = $url_keys[$k];
        }
    }

    # Set new route name, delete old name
    $GLOBALS['routes'][$final_name]['route'] = $route;
    unset($GLOBALS['routes'][$i]);
}

@$_GET['vars'] = $GLOBALS['routes'][$_GET['url']]['vars'];
@$_GET['url'] = $GLOBALS['routes'][$_GET['url']]['route'];

# Autoload all source files and the current controller
function __autoload($className) {
    # Source
    if(file_exists(SYSTEM . "$className.php")) # Load source classes
        require_once(SYSTEM . "$className.php");
    
    # Controllers
    if(file_exists(CONTROLLERS . $_GET['url'] . ".controller.php")) { # Load controller
        require_once(CONTROLLERS . $_GET['url'] . ".controller.php");
    }

    else {
        exit(ERR_NOT_FOUND);
    }
}

# Initialize global styles and scripts variables, so they can later be used
$styles = array();
$scripts = array();

$styles_archive = array();
$scripts_archive = array();

# Get language file, if it exists
$lang_path = "data/language/" . $_SESSION['language'] . "/" . $_GET['url'] . ".lang.php";

if(file_exists($lang_path))
    require_once($lang_path);
    
# Init
Controller::init();

if(DEBUG_CONSOLE)
    Controller::controller("console/console");
