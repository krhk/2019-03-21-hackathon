gulp = require 'gulp'
sass = require 'gulp-sass'
concat = require 'gulp-concat'
minifyStyles = require 'gulp-clean-css'
minifyScripts = require 'gulp-minify'

paths = {
	stylesFrontend: [
	#	'node_modules/bootstrap/dist/css/bootstrap.min.css',
		'www/files/styles/source/frontend.scss',
	],
	stylesBackedn: [
	#	'node_modules/bootstrap/dist/css/bootstrap.min.css',
		'www/files/styles/source/backend.scss',
	],
	scriptsFrontend: [
		'node_modules/bootstrap/dist/js/bootstrap.min.js',
		'vendor/nette/forms/src/assets/netteForms.min.js',
		'www/files/scripts/source/frontend.js',
	],
	scriptsBackedn: [
		'node_modules/bootstrap/dist/js/bootstrap.min.js',
		'vendor/nette/forms/src/assets/netteForms.min.js',
		'www/files/scripts/source/backedn.js',
	]
}

# Compile SASS files
gulp.task 'styles', ->
	# Frontend styles
	gulp.src paths.stylesFrontend
		.pipe sass()
		.pipe minifyStyles()
		.pipe concat 'combined-frontend.min.css'
		.pipe gulp.dest 'www/files/styles'

	# Backend styles
	gulp.src paths.stylesBackedn
		.pipe sass()
		.pipe minifyStyles()
		.pipe concat 'combined-backend.min.css'
		.pipe gulp.dest 'www/files/styles'

# Compile JavaScript files
gulp.task 'scripts', ->
	# Frontend scripts
	gulp.src paths.scripts
		.pipe minifyScripts {noSource: true}
		.pipe concat 'frontend.min.js'
		.pipe gulp.dest 'www/files/scripts'

	# Backedn scripts
	gulp.src paths.scripts
		.pipe minifyScripts {noSource: true}
		.pipe concat 'backend.min.js'
		.pipe gulp.dest 'www/files/scripts'


# Development watcher
gulp.task 'watch', ->
	gulp.watch 'www/files/scripts/source/*.js', gulp.parallel ['scripts']
	gulp.watch 'www/files/styles/source/*.scss', gulp.parallel ['styles']

# Application build
gulp.task 'build', gulp.parallel ['styles', 'scripts']