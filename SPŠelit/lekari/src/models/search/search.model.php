<?php

class ModelSearchSearch extends Model {

    public function get(string $q): array {
        # Set shortcuts for better searching experience
        $shortcuts = array(
            "stomatologie" => "stomatologická pohotovost",
            "stomatolog"   => "stomatologická pohotovost",
            "zubař"        => "stomatologická pohotovost"
        );

        # Look for shortcut
        if(!empty($shortcuts[$q]))
            $q = $shortcuts[$q];

        # Normal query
        $details_all = $this->query(
            "SELECT * FROM details WHERE
                doc_phone = :q OR
                okres_code = :q OR
                obec_code = :q OR
                doc_code = :q
            ",
            [
                ":q" => $q
            ]
        );

        # If match is found, return results, to prevent inaccurate results due to phonetics
        if(!empty($details_all[0]))
            return $details_all;

        # Query using SOUNDEX
        $details_all = $this->query(
            "SELECT * FROM details WHERE
                SOUNDEX(type) = SOUNDEX(:q) OR
                SOUNDEX(who) = SOUNDEX(:q) OR
                SOUNDEX(okres_name) = SOUNDEX(:q) OR
                SOUNDEX(obec_name) = SOUNDEX(:q) OR
                SOUNDEX(doc_name) = SOUNDEX(:q) OR
                SOUNDEX(doc_street) = SOUNDEX(:q)
            ", 
            [
                ":q" => $q
            ]
        );

        # Return all results of query
        return $details_all;
    }

    # Search with filters
    public function get_with_filters(array $filters_arr) {
        $query_string = "";
        
        foreach($filters_arr as $key => $col) {
            if(empty($col))
                continue;

            if($query_string != "")
                $query_string .= " AND "; 

            $query_string .= "SOUNDEX(" . $key . ")=" . "SOUNDEX('" . $col['value'] . "')";
        }

        $query_string = "SELECT * FROM details WHERE " . $query_string;

        return $this->query($query_string);
    }

    public function okres_get_all() {
        $okres_all = $this->query("SELECT okres_name FROM details");
        $okres_return = array();

        foreach($okres_all as $okres) {
            if(in_array($okres['okres_name'], $okres_return))
                continue;
            else
                array_push($okres_return, $okres['okres_name']);
        }

        return $okres_return;
    }

    public function obec_get_all() {
        $obce_all = $this->query("SELECT obec_name FROM details");
        $obec_return = array();

        foreach($obce_all as $obec) {
            if(in_array($obec['obec_name'], $obec_return))
                continue;
            else
                array_push($obec_return, $obec['obec_name']);
        }

        return $obec_return;
    }

}