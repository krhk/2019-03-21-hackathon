<?php

class ControllerSearchSearch extends Controller {

    public function index() {
        $model = $this->load->model("search/search");

        # Styles / Scripts
        $this->load->style("search/search-page");
        $this->load->style("search/filter-page");
        $this->load->style("search/results");

        $this->load->script("jquery.min");
        $this->load->script("filter");
        $this->load->script("main");
        $this->load->script("nav");

        $data['okresy'] = $model->okres_get_all();
        $data['obce'] = $model->obec_get_all();

        # Partials
        $data['nav'] = $this->load->view("partials/nav");
        $data['footer'] = $this->load->view("partials/footer");

        # Language
        $lang = $this->load->language("search/search");

        # Display view for search
        $this->display("search/search", $data);
    }

}