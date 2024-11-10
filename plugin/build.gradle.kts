buildscript {
    repositories {
        google()  // Google repository
        mavenCentral() // Maven repository
    }
    dependencies {
        /
        classpath 'com.android.tools.build:gradle:8.4.1' 
    }
}

allprojects {
    repositories {
        google()
        mavenCentral()
    }
}
android {
    compileSdkVersion 35
}
