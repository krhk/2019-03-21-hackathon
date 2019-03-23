<?php

class ControllerSearchResults extends Controller {

    public function index() {
        # Load search model
        $model_search = $this->load->model("search/search");

        # Initialize search results as array so we don't get a warning
        $data['search_results'] = array();

        if(isset($_POST['search_subm'])) {
            $data['search_results'] = $model_search->get($_POST['q']);
        }

        if(isset($_POST['search_filters_subm'])) {
            $data['search_results'] = $model_search->get_with_filters([
                "type" => $_POST['type'],
                "who" => $_POST['who'],
                "okres_name" => $_POST['okres_name'],
                "obec_name" => $_POST['obec_name']
            ]);
        }

        # Load styles / scripts
        $this->load->style("search/results");

        # Display view for results
        $this->display("search/results", $data);
    }

}