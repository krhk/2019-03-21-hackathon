<?php

class URL {
    public function link($path) {

        # Return short URL if it is set
        foreach(array_keys($GLOBALS['routes']) as $key) {
            if($GLOBALS['routes'][$key] == $path)
                return ROOT . $key;
        }

        # Return full URL, if short URL is not set
        return ROOT . $path;
    }

    public function reload($params = []) {
        header("Location:" . ROOT . $_GET['url'] . $params);
    }
}