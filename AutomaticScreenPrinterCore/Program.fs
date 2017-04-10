module Main

open AutomaticScreenPrinterGui
open System
open System.Windows
open Application

[<STAThread>]
[<EntryPoint>]
let main argv = 

    let app = new ScreenPrinterApplication();
    let window = new MainWindow(app);
    app.Run(window)

