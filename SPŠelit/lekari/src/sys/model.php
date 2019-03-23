<?php

class Model {

    static protected $dbhost = DB_HOST;
    static protected $dbname = DB_NAME;
    static protected $dbuser = DB_USER;
    static protected $dbpass = DB_PASS;

    public static function connect() {
        $pdo = new PDO("mysql:host=".self::$dbhost.";dbname=".self::$dbname.";charset=utf8mb4", self::$dbuser, self::$dbpass);
        return $pdo;
    }

    public static function query(string $query, array $params = []) {
        $stmnt = self::connect()->prepare($query);

        foreach($params as $key => $param) {
            $params[$key] = htmlspecialchars($param);
        }

        $stmnt->execute($params);

        if(explode(" ", $query)[0] == "SELECT") {
            $data = $stmnt->fetchAll(PDO::FETCH_ASSOC);

            if($data == null)
                return [$data]; # Return data in array, only containing null in the position 0

            return $data;
        }
    }

}