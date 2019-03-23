<?php

class ControllerConsoleConsole extends Controller {

    public function index() {
        
        # Commands
        if(isset($_POST['command_subm'])) {
            $commands = array(
                "check memory" => function() {
                    echo "Memory usage: " . memory_get_usage() / 1000000 . "MB";
                },

                "list scripts" => function() {
                    if(empty($GLOBALS['scripts_archive'])) {
                        echo "<p>No scripts loaded.</p>";
                        return;
                    }

                    echo "--- " . sizeof($GLOBALS['scripts_archive']) . " script(s) loaded ---";

                    foreach($GLOBALS['scripts_archive'] as $key => $script) {
                        echo "<p>" . ($key + 1) . ". $script</p>";
                    }
                },
                
                "list styles" => function() {
                    if(empty($GLOBALS['styles_archive'])) {
                        echo "<p>No styles loaded.</p>";
                        return;
                    }

                    echo "--- " . sizeof($GLOBALS['styles_archive']) . " style(s) loaded ---";

                    foreach($GLOBALS['styles_archive'] as $key => $style) {
                        echo "<p>" . ($key + 1) . ". $style</p>";
                    }
                }
            );

            $prefix = $_POST['prefix'];
            $value = $_POST['value'];

            $command = $prefix . " " . $value;

            $commands[(string)$command]();
            exit();
        }

        # Data
        $data['hello'] = "mattLib debug console 0.0.1";
        
        $this->load->script("console/jq");
        $this->load->script("console/console");
        
        $this->load->style("console/console");

        # Display console
        $this->display("console/console", $data);
    }

}