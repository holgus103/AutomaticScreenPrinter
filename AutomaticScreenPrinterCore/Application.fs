module Application 


open AutomaticScreenPrinterGui
open System.Timers
open System.Windows
open System.Drawing
open System.Windows.Forms
open System
open System.Drawing.Imaging

type ScreenPrinterApplication() = 
    inherit System.Windows.Application()
    interface IApplicationInterface with
        member val FilePath = "" with get, set
        member val Interval = 5000 with get, set
        member this.Execute ()  = 
            let timer = new System.Timers.Timer()
            timer.Interval <- (this :> IApplicationInterface).Interval |> float
            timer.Enabled <- true
            timer.AutoReset <- true
            timer.Start()
            timer.Elapsed.Add(fun x -> 
                let screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
                let gfx = Graphics.FromImage(screen)
                gfx.CopyFromScreen(0, 0, 0, 0, screen.Size)
                let path = (this :> IApplicationInterface).FilePath + "\\" + DateTime.Now.ToString().Replace('/', '-').Replace(':', '-') + ".jpg"
                screen.Save(path, ImageFormat.Jpeg))
            ()

    

            
    

