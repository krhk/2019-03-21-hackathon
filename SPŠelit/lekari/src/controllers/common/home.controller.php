<?php

class ControllerCommonHome extends Controller {

    public function index() {
        $data['text_hello'] = $this->language->get("hello");
        $data['text_name'] = $this->language->get("name");

        $this->display("common/home", $data);
    }

}