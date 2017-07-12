// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using CefSharp;
using System;
using System.IO;
using System.Windows.Forms;


namespace BorderLessBrowser
{
    public class Program
    {
        private static Form browser;
        

        [STAThread]
        public static void Main()
        {

            Control.CheckForIllegalCrossThreadCalls = false;
            var updater = FSLib.App.SimpleUpdater.Updater.Instance;
            updater.NoUpdatesFound += new EventHandler(Program.updater_noUpdatesFound);
            FSLib.App.SimpleUpdater.Updater.CheckUpdateSimple("http://www.netroby.cn/download/{0}", "update.xml");
            
            //For Windows 7 and above, best to include relevant app.manifest entries as well
            Cef.EnableHighDPISupport();

            var settings = new CefSettings()
            {
                //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(settings);
            
            browser = new BrowserForm();
            Application.Run(browser);
            Cef.Shutdown();

        }
        /**
         * 如果没有更新,就把浏览器设置为置顶窗口
         */
        public static void  updater_noUpdatesFound(object sender, EventArgs e)
        {
            browser.TopMost = true;
        }
    }
}
