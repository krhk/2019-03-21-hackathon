<?php

class ModelConsoleConsole extends Model {

    public function checkConnection() {
        if(!$this->query("SELECT 1"))
            return false;
        
        return true;
    }

}