<?php

# Roots
define("ROOT", "/lekari/");

define("SYSTEM", "src/sys/");
define("CONTROLLERS", "src/controllers/");
define("MODELS", "src/models/");
define("VIEWS", "public/views/themes/");
define("LANGUAGE", "data/language/");

# Files
define("MAX_FILESIZE", 1000000); // 1 MB

# Database
define("DB_HOST", "localhost");
define("DB_NAME", "lekari");
define("DB_USER", "root");
define("DB_PASS", "");

# Web
define("HOMEPAGE", "search");
define("DEFAULT_LANGUAGE", "cz");
define("DEFAULT_THEME", "default");

# Errors
define('ERR_NOT_FOUND', "404, page not found!");
define('ERR_FORBIDEN', "Permission denied!");

# Debug console
define("DEBUG_CONSOLE", false);