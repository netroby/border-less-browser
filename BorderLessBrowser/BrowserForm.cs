// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Windows.Forms;
using BorderLessBrowser.Controls;
using CefSharp.WinForms;
using BorderLessBrowser.Handlers;

namespace BorderLessBrowser

{
    public partial class BrowserForm : Form
    {
        private readonly ChromiumWebBrowser browser;

        public BrowserForm()
        {
            InitializeComponent();

            Text = "BorderLessBrowser " + ProductVersion;

            browser = new ChromiumWebBrowser("")
            {
                Dock = DockStyle.Fill,
            };
            browser.LifeSpanHandler = new LifeSpanHandler();
            browser.Width = 720;
            browser.Height = 480;
            string DefaultHtml = "<html><head><title>Home</title><body><div style=\"margin: 100px auto; width: 500px\"><form action = \"https://www.sogou.com/web\" ><input type=\"text\" name=\"query\" style=\"width:320px;height:40px;font-size:24px;float:left\"><button type=\"submit\"  style=\"width:120px;height:40px;float:left;margin:0px 10px\">Go</button></form></div>";
            CefSharp.WebBrowserExtensions.LoadHtml(browser, DefaultHtml, false);
            toolStripContainer.ContentPanel.Controls.Add(browser);
        }

        
    }
}
