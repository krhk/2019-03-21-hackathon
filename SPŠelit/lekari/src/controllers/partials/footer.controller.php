<?php

class ControllerPartialsFooter extends Controller {

    public function index() {

        # Load styles / scripts
        $this->load->style("partials/footer");

        # Language        
        $this->load->language("partials/footer");

        # Display view for footer
        $this->display("partials/footer");
    }

}