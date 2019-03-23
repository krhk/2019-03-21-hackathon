<?php

class ControllerPartialsNav extends Controller {

    public function index() {
        # Load styles / scripts
        $this->load->style("root");
        $this->load->style("simple-grid");
        $this->load->style("partials/nav");

        # Language        
        $this->load->language("partials/nav");

        # Display view for header
        $this->display("partials/nav");
    }

}