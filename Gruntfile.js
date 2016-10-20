module.exports = function (grunt) {

	var path = require('path');

	// Load the package JSON file
	var pkg = grunt.file.readJSON('package.json');

	// Load information about the assembly
	var assembly = grunt.file.readJSON('src/Skybrud.Colors/Properties/AssemblyInfo.json');

	// Get the version of the package
	var version = assembly.informationalVersion ? assembly.informationalVersion : assembly.version;

	grunt.initConfig({
		pkg: pkg,
		nugetpack: {
			colors: {
				src: 'src/Skybrud.Colors/Skybrud.Colors.csproj',
				dest: 'releases/nuget/'
			}
		},
		zip: {
			release: {
				router: function (filepath) {
					return path.basename(filepath);
				},
				src: [
					'src/Skybrud.Colors/bin/Release/Skybrud.Colors.dll',
					'src/Skybrud.Colors/bin/Release/Skybrud.Colors.xml',
					'src/Skybrud.Colors/LICENSE.txt'
				],
				dest: 'releases/github/Skybrud.Colors.v' + version + '.zip'
			}
		}
	});

	grunt.loadNpmTasks('grunt-nuget');
	grunt.loadNpmTasks('grunt-zip');

	grunt.registerTask('release', ['nugetpack', 'zip']);

	grunt.registerTask('default', ['release']);

};