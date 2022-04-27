package com.unity.ba;
import com.unity3d.player.UnityPlayerActivity;
import android.os.Bundle;
import android.os.Build;

public class OverrideExample extends UnityPlayerActivity {
    private boolean preferVulkan() {
        // Use Vulkan on Google Pixel devices
        if (Build.MANUFACTURER.equals("Google") && Build.MODEL.startsWith("Pixel"))
            return true;
        else
            return false;
    }

    private boolean preferES2() {
        // Use OpenGL ES 2.0 on devices that run Android 5.1 or older
        if (Build.VERSION.SDK_INT <= Build.VERSION_CODES.LOLLIPOP_MR1)
            return true;
        else
            return false;
    }

    private String appendCommandLineArgument(String cmdLine, String arg) {
        if (arg == null || arg.isEmpty())
            return cmdLine;
        else if (cmdLine == null || cmdLine.isEmpty())
            return arg;
        else
            return cmdLine + " " + arg; 
    } 

    protected String updateUnityCommandLineArguments(String cmdLine)
    {
    	cmdLine = appendCommandLineArgument(cmdLine, "-platform-android-unitymain-affinity any");
    	cmdLine = appendCommandLineArgument(cmdLine, "-platform-android-jobworker-affinity any");
    	cmdLine = appendCommandLineArgument(cmdLine, "-platform-android-unitymain-priority -3 -platform-android-gfxdeviceworker-priority -4");
        if (preferVulkan())
            return appendCommandLineArgument(cmdLine, "-force-vulkan");
        else if (preferES2())
            return appendCommandLineArgument(cmdLine, "-force-gles20");
        else
            return cmdLine; // let Unity pick the Graphics API based on PlayerSettings
    }

    @Override protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
    }
}

