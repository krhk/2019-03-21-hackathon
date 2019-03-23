<?php 
    class Connection {
        //URL
        public $url;
        public $parsedUrl;
        public $switchUrl;

        //page
        public $pageTitle;
        public $file;
        public $layout;

        public function __construct(){
            $this->url = $_SERVER['REQUEST_URI'];
            $this->parsedUrl = $this->parseURL();
            $this->switchUrl = $this->urlForSwitch();

            $this->switch();
        }

        private function parseURL() {
            $naparsovanaURL = parse_url($_SERVER['REQUEST_URI']);
            $naparsovanaURL["path"] = ltrim($naparsovanaURL["path"], "/");
            $naparsovanaURL["path"] = trim($naparsovanaURL["path"]);
            $rozdelenaCesta = explode("/", $naparsovanaURL["path"]);
            return $rozdelenaCesta;
        }

        private function urlForSwitch(){
            $result = $this->parsedUrl[0];
            if(isset($this->parsedUrl[1])){if($this->parsedUrl[1]!="")$result .= "/".$this->parsedUrl[1];}
            if(isset($this->parsedUrl[2])){if($this->parsedUrl[2]!="")$result .= "/".$this->parsedUrl[2];}
            if(isset($this->parsedUrl[3])){if($this->parsedUrl[3]!="")$result .= "/".$this->parsedUrl[3];} 

            return $result;
        }

        private function switch(){
            $settingsSwitch = file_get_contents("settings/switch.json");
            $switchJson = json_decode($settingsSwitch, true);

            foreach($switchJson["alike"] as $alike){
                if($alike["from"]==$this->switchUrl) $this->switchUrl = $alike["to"];
            }


            //404
            $this->pageTitle = "Chyba 404";
            $this->file = "page/login/404.php";
            $this->layout = "layout/login/template.php";

            foreach($switchJson["switch"] as $sw){
                if($sw["url"]==$this->switchUrl){
                    $this->pageTitle = $sw["title"];
                    $this->file = $sw["file"];
                    $this->layout = $sw["layout"];

                    break;
                }
            }
        }

    }
?>