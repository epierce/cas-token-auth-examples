cas-token-auth-examples
=======================

## CAS server
A Maven overlay of CAS server with just the required changes to test the cas-server-extension-token module.

#### To start the CAS server:
1. Install [Maven](http://maven.apache.org)
2. Install [Tomcat](http://tomcat.apache.org) 
3. `mvn clean package`
4. `cp target/cas.war $TOMCAT/webapps/.`
5. `$TOMCAT/bin/startup.sh`


## Client examples
Example applications that accept user input and generate a token.  Each of the applications are built using [Twitter Bootstrap](http://twitter.github.io/bootstrap/) and accepts the following data from the user:

* CAS server URL
* Username
* First Name
* Last Name
* Email address

###PHP
Requires [MCrypt](http://mcrypt.sourceforge.net/) and the [MCrypt PHP module](http://php.net/manual/en/book.mcrypt.php).

###Grails
Built with [Grails 2.2.2](http://grails.org) using the [Kickstart with Bootstrap](http://grails.org/plugin/kickstart-with-bootstrap) plugin

###DotNet
Built using the standard .Net libraries using [Mono 2.10.x](http://www.mono-project.com).

###Ruby on Rails (to-do)

###Django (to-do)

###Node (to-do)
