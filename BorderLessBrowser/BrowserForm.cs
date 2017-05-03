// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Windows.Forms;
using BorderLessBrowser.Controls;
using CefSharp.WinForms;
using BorderLessBrowser.Handlers;
using AutoUpdaterDotNET;

namespace BorderLessBrowser
   
{
    public partial class BrowserForm : Form
    {
        private readonly ChromiumWebBrowser browser;

        public BrowserForm()
        {
            InitializeComponent();

            Text = "BorderLessBrowser " + ProductVersion;

            browser = new ChromiumWebBrowser("https://www.bing.com")
            {
                Dock = DockStyle.Fill,
            };
            browser.LifeSpanHandler = new LifeSpanHandler();
            browser.Width = 720;
            browser.Height = 480;
            toolStripContainer.ContentPanel.Controls.Add(browser);
            
            AutoUpdater.Start("https://catsh.us/version.xml");
        }
        
        private void LoadUrl(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                browser.Load(url);
            }
        }
        
    }
}
