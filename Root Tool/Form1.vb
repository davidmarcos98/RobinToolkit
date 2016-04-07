Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Windows.Forms.DialogResult
Public Class Form1
    Private Sub Form1_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox2.Image = My.Resources.notdetected
        PictureBox6.Image = My.Resources.nextbitlogo
        PictureBox3.Image = My.Resources.supersu1
        PictureBox4.Image = My.Resources.backup
        PictureBox8.Image = My.Resources._0
        PictureBox12.Image = My.Resources.twrplogo
        If Not Directory.Exists("C:\RobinToolkit") Then
            Directory.CreateDirectory("C:\RobinToolkit")
        End If
        If Not Directory.Exists("C:\RobinToolkit\ADB") Then
            Directory.CreateDirectory("C:\RobinToolkit\ADB")
        End If
        If Not Directory.Exists("ADB") Then
            Directory.CreateDirectory("ADB")
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\adb.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\adb.exe", My.Resources.adb)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\AdbWinApi.dll") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\AdbWinApi.dll", My.Resources.AdbWinApi)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\AdbWinUsbApi.dll") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\AdbWinUsbApi.dll", My.Resources.AdbWinUsbApi)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\fastboot.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\fastboot.exe", My.Resources.fastboot)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\supersu.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\supersu.exe", My.Resources.supersu)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\adbdevices.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\adbdevices.exe", My.Resources.adbdevices)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\boot.img") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\boot.img", My.Resources.boot)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\recovery.img") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\recovery.img", My.Resources.recovery)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\flash_all.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\flash_all.exe", My.Resources.flash_all)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\twrp.img") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\twrp.img", My.Resources.twrp)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\nonencrypt.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\nonencrypt.exe", My.Resources.nonencrypt)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\flash_recsys.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\flash_recsys.exe", My.Resources.flash_recsys)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\flash_recboot.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\flash_recboot.exe", My.Resources.flash_recboot)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\flash_bootsys.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\flash_bootsys.exe", My.Resources.flash_bootsys)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\flash_rec.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\flash_rec.exe", My.Resources.flash_rec)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\flash_boot.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\flash_boot.exe", My.Resources.flash_boot)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\flash_sys.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\flash_sys.exe", My.Resources.flash_sys)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\UnRAR.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\UnRAR.exe", My.Resources.UnRAR)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\fastboot") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\fastboot", My.Resources.fastboot_file)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\Phone_Nextbit_USB_Driver_v1_0_1.msi") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\Phone_Nextbit_USB_Driver_v1_0_1.msi", My.Resources.Phone_Nextbit_USB_Driver_v1_0_1)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\setup.exe") Then
            File.WriteAllBytes("C:\RobinToolkit\ADB\setup.exe", My.Resources.setup)
        End If
        If Not File.Exists("C:\RobinToolkit\ADB\system.img") Then
            CheckBox4.Enabled = False
        End If
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    'Root
    Private Sub Button1_Click(Sender As Object, e As EventArgs) Handles Button1.Click
        Dim result1 As DialogResult = MessageBox.Show("If your device Is still locked, this process will wipe ALL your data. Do you want to continue?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            MessageBox.Show("Don't do anything until you get a 'Finished' message")
            PictureBox1.Image = My.Resources.reboot
            Shell("CMD.exe /C adb reboot bootloader & cd ADB & fastboot -i 0x2c3f oem unlock & fastboot -i 0x2c3f flash recovery twrp.img", 0)
            Delay(20)
            PictureBox1.Image = My.Resources.rooting
            Shell("CMD.exe /C adb shell twrp sideload && TIMEOUT 1", 0)
            Delay(8)
            PictureBox1.Image = My.Resources.rooting
            Process.Start("C:\RobinToolkit\ADB\supersu.exe", 0).WaitForExit()
            PictureBox1.Image = My.Resources.rooted
            MessageBox.Show("Finished!")
            Shell("CMD.exe /C adb reboot", 0)
        End If
    End Sub
    'Background check device
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If CheckIfFtpFileExists("ftp://ftp.daavm.com/wp-content/uploads/2016/04/update1.1.txt") Then
            Dim result1 As DialogResult = MessageBox.Show("There's an update available, wanna update now?",
                                         "Important Question",
                                         MessageBoxButtons.YesNo)
            If result1 = DialogResult.Yes Then
                Dim webAddress As String = "http://www.daavm.com/wp-content/uploads/2016/04/RobinToolkit.1.1.rar"
                Process.Start("Chrome", webAddress)
            End If
        End If
        MessageBox.Show("Connect your Robin And activate Android Debugging in developer settings", "Welcome")
        Process.Start("C:\RobinToolkit\ADB\adbdevices.exe", 0).WaitForExit()
        PictureBox2.Image = My.Resources.detected
    End Sub
    Public Function CheckIfFtpFileExists(ByVal fileUri As String) As Boolean
        Dim request As FtpWebRequest = WebRequest.Create(fileUri)
        request.Credentials = New NetworkCredential("u691812957.public", "hello1234")
        request.Method = WebRequestMethods.Ftp.GetFileSize
        Try
            Dim response As FtpWebResponse = request.GetResponse()
            ' THE FILE EXISTS
        Catch ex As WebException
            Dim response As FtpWebResponse = ex.Response
            If FtpStatusCode.ActionNotTakenFileUnavailable = response.StatusCode Then
                ' THE FILE DOES NOT EXIST
                Return False
            End If
        End Try
        Return True
    End Function
    'Backups
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim result1 As DialogResult = MessageBox.Show("Your device MUST be unlocked, or the process will wipe your data, and no backup will be done. Do you want to continue?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            PictureBox7.Image = My.Resources._0
            MessageBox.Show("Don't do anything until you get a 'Finished' message")
            Shell("CMD.exe /C adb reboot bootloader & cd C:\RobinToolkit\ADB & fastboot -i 0x2c3f oem unlock & fastboot -i 0x2c3f flash recovery twrp.img", 0)
            Delay(20)
            Shell("CMD.exe /C adb shell twrp backup SDCRBOM", 0, 1)
            Shell("CMD.exe /C rd /q /s C:\RobinToolkit\backup & mkdir C:\RobinToolkit\backup", 0, 1)
            PictureBox7.Image = My.Resources._50
            Shell("CMD.exe /C cd C:\RobinToolkit\backup & adb pull SDCRBOM /sdcard/TWRP/BACKUPS/ .", 0, 1)
            Shell("CMD.exe /C adb shell & rm -rR /sdcard/TWRP/BACKUPS", 0, 1)
            PictureBox7.Image = My.Resources._100
            Shell("CMD.exe /C adb reboot", 0)
            MessageBox.Show("Finished!")
        End If
    End Sub
    'Restore
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Not Directory.Exists("C:\RobinToolkit\backup") Then
            MessageBox.Show("You must have a backup done before trying to restore anything", "No backup found")
        Else
            PictureBox5.Image = My.Resources._0
            Dim result1 As DialogResult = MessageBox.Show("If your device is still locked, this process will wipe ALL your data. Do you want to continue?",
                                  "Important Question",
                                  MessageBoxButtons.YesNo)
            If result1 = DialogResult.Yes Then
                MessageBox.Show("Don't do anything until you get a 'Finished' message")
                Shell("CMD.exe /C adb reboot bootloader & cd C:\RobinToolkit\ADB & fastboot -i 0x2c3f oem unlock & fastboot -i 0x2c3f flash recovery twrp.img", 0)
                Delay(20)
                Shell("CMD.exe /C adb shell & mkdir /sdcard/TWRP/BACKUPS", , 1)
                Shell("CMD.exe /C cd C:\RobinToolkit\backup & adb push . /sdcard/TWRP/BACKUPS ", , 1)
                PictureBox5.Image = My.Resources._50
                Shell("CMD.exe /C adb shell & cd /sdcard/TWRP/BACKUPS/* & TWRP restore SDCRBM", , 1)
                PictureBox5.Image = My.Resources._100
                Shell("CMD.exe /C adb reboot")
                MessageBox.Show("Finished!")
            End If
        End If
    End Sub
    'Leave Stock
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PictureBox8.Image = My.Resources._0
        If CheckBox2.Checked Then
            If CheckBox3.Checked Then
                If CheckBox4.Checked Then
                    'all
                    Dim result1 As DialogResult = MessageBox.Show("This process will wipe ALL your data. Do you want to continue?",
                                  "Important Question",
                                  MessageBoxButtons.YesNo)
                    If result1 = DialogResult.Yes Then
                        MessageBox.Show("Don't do anything until you get a 'Finished' message")
                        Dim result2 As DialogResult = MessageBox.Show("Does your phone boot?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
                        If result2 = DialogResult.Yes Then
                            Shell("CMD.exe /C adb reboot bootloader")
                        End If
                        If result2 = DialogResult.No Then
                            MessageBox.Show("Boot your phone into fastboot mode (Vol - and Power Buttons, and hit accept when you see Android Robot to continue")
                        End If
                        PictureBox8.Image = My.Resources._50
                        Process.Start("C:\RobinToolkit\ADB\flash_all.exe")
                        PictureBox8.Image = My.Resources._100
                        MessageBox.Show("Finished!")
                    End If
                Else
                    MessageBox.Show("Don't do anything until you get a 'Finished' message")
                    Dim result2 As DialogResult = MessageBox.Show("Does your phone boot?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
                    If result2 = DialogResult.Yes Then
                        Shell("CMD.exe /C adb reboot bootloader")
                    End If
                    If result2 = DialogResult.No Then
                        MessageBox.Show("Boot your phone into fastboot mode (Vol - and Power Buttons, and hit accept when you see Android Robot to continue")
                    End If
                    PictureBox8.Image = My.Resources._50
                    Process.Start("C:\RobinToolkit\ADB\flahs_recboot.exe")
                    PictureBox8.Image = My.Resources._100
                    MessageBox.Show("Finished!")
                End If
            Else
                If CheckBox4.Checked Then
                    Dim result1 As DialogResult = MessageBox.Show("This process will wipe ALL your data. Do you want to continue?",
                                  "Important Question",
                                  MessageBoxButtons.YesNo)
                    If result1 = DialogResult.Yes Then
                        MessageBox.Show("Don't do anything until you get a 'Finished' message")
                        Dim result2 As DialogResult = MessageBox.Show("Does your phone boot?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
                        If result2 = DialogResult.Yes Then
                            Shell("CMD.exe /C adb reboot bootloader")
                        End If
                        If result2 = DialogResult.No Then
                            MessageBox.Show("Boot your phone into fastboot mode (Vol - and Power Buttons, and hit accept when you see Android Robot to continue")
                        End If
                        PictureBox8.Image = My.Resources._50
                        Process.Start("C:\RobinToolkit\ADB\flash_recsys.exe")
                        PictureBox8.Image = My.Resources._100
                        MessageBox.Show("Finished!")
                    End If
                Else
                    MessageBox.Show("Don't do anything until you get a 'Finished' message")
                    Dim result2 As DialogResult = MessageBox.Show("Does your phone boot?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
                    If result2 = DialogResult.Yes Then
                        Shell("CMD.exe /C adb reboot bootloader")
                    End If
                    If result2 = DialogResult.No Then
                        MessageBox.Show("Boot your phone into fastboot mode (Vol - and Power Buttons, and hit accept when you see Android Robot to continue")
                    End If
                    PictureBox8.Image = My.Resources._50
                    Process.Start("C:\RobinToolkit\ADB\flash_rec.exe")
                    PictureBox8.Image = My.Resources._100
                    MessageBox.Show("Finished!")
                End If
            End If
        Else
            If CheckBox3.Checked Then
                If CheckBox4.Checked Then
                    Dim result1 As DialogResult = MessageBox.Show("This process will wipe ALL your data. Do you want to continue?",
                                  "Important Question",
                                  MessageBoxButtons.YesNo)
                    If result1 = DialogResult.Yes Then
                        MessageBox.Show("Don't do anything until you get a 'Finished' message")
                        Dim result2 As DialogResult = MessageBox.Show("Does your phone boot?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
                        If result2 = DialogResult.Yes Then
                            Shell("CMD.exe /C adb reboot bootloader")
                        End If
                        If result2 = DialogResult.No Then
                            MessageBox.Show("Boot your phone into fastboot mode (Vol - and Power Buttons, and hit accept when you see Android Robot to continue")
                        End If
                        PictureBox8.Image = My.Resources._50
                        Process.Start("C:\RobinToolkit\ADB\flash_bootsys.exe")
                        PictureBox8.Image = My.Resources._100
                        MessageBox.Show("Finished!")
                    End If
                Else
                    MessageBox.Show("Don't do anything until you get a 'Finished' message")
                    Dim result2 As DialogResult = MessageBox.Show("Does your phone boot?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
                    If result2 = DialogResult.Yes Then
                        Shell("CMD.exe /C adb reboot bootloader")
                    End If
                    If result2 = DialogResult.No Then
                        MessageBox.Show("Boot your phone into fastboot mode (Vol - and Power Buttons, and hit accept when you see Android Robot to continue")
                    End If
                    PictureBox8.Image = My.Resources._50
                    Process.Start("C:\RobinToolkit\ADB\flash_boot.exe")
                    PictureBox8.Image = My.Resources._100
                    MessageBox.Show("Finished!")
                End If
            Else
                If CheckBox4.Checked Then
                    Dim result1 As DialogResult = MessageBox.Show("This process will wipe ALL your data. Do you want to continue?",
                                  "Important Question",
                                  MessageBoxButtons.YesNo)
                    If result1 = DialogResult.Yes Then
                        MessageBox.Show("Don't do anything until you get a 'Finished' message")
                        Dim result2 As DialogResult = MessageBox.Show("Does your phone boot?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
                        If result2 = DialogResult.Yes Then
                            Shell("CMD.exe /C adb reboot bootloader")
                        End If
                        If result2 = DialogResult.No Then
                            MessageBox.Show("Boot your phone into fastboot mode (Vol - and Power Buttons, and hit accept when you see Android Robot to continue")
                        End If
                        PictureBox8.Image = My.Resources._50
                        Process.Start("C:\RobinToolkit\ADB\flash_sys.exe")
                        PictureBox8.Image = My.Resources._100
                        MessageBox.Show("Finished!")
                    End If
                Else
                    MessageBox.Show("Please select at least one of the options above!")
                End If
            End If
        End If
    End Sub
    'Non-encryption Boot
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        PictureBox9.Image = My.Resources._0
        Dim result1 As DialogResult = MessageBox.Show("This process will wipe ALL your data. Do you want to continue?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            MessageBox.Show("Don't do anything until you get a 'Finished' message")
            Shell("CMD.exe /C adb reboot bootloader & cd ADB & fastboot -i 0x2c3f oem unlock & fastboot -i 0x2c3f flash recovery twrp.img", 0)
            Delay(20)
            Shell("CMD.exe /C adb shell & twrp wipe data & twrp wipe cache & twrp wipe dalvik", 0)
            PictureBox9.Image = My.Resources._50
            Shell("CMD.exe /C adb shell twrp sideload", 0)
            Process.Start("C:\RobinToolkit\ADB\nonencrypt.exe", 0).WaitForExit()
            PictureBox9.Image = My.Resources._100
            MessageBox.Show("Finished!")
            Shell("CMD.exe /C adb reboot")
        End If
    End Sub
    'Wipe Data
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        PictureBox10.Image = My.Resources._0
        Dim result1 As DialogResult = MessageBox.Show("This process will wipe ALL your data. Do you want to continue?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            MessageBox.Show("Don't do anything until you get a 'Finished' message")
            Shell("CMD.exe /C adb reboot bootloader & cd ADB & fastboot -i 0x2c3f oem unlock & fastboot -i 0x2c3f flash recovery twrp.img", 0)
            Delay(20)
            PictureBox10.Image = My.Resources._50
            Shell("CMD.exe /C adb shell & twrp wipe data & twrp wipe cache & twrp wipe dalvik", 0, 1)
            PictureBox10.Image = My.Resources._100
            MessageBox.Show("Finished!")
            Shell("CMD.exe /C adb reboot", 0)
        End If
    End Sub
    'Wipe Cache
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        PictureBox10.Image = My.Resources._0
        Dim result1 As DialogResult = MessageBox.Show("If your device is still locked, this process will wipe ALL your data. Do you want to continue?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Shell("CMD.exe /C adb reboot bootloader & cd ADB & fastboot -i 0x2c3f oem unlock & fastboot -i 0x2c3f flash recovery twrp.img", 0)
            Delay(20)
            PictureBox10.Image = My.Resources._50
            Shell("CMD.exe /C adb shell & twrp wipe cache & twrp wipe dalvik", 0, 1)
            PictureBox10.Image = My.Resources._100
            MessageBox.Show("Finished!")
            Shell("CMD.exe /C adb reboot")
        End If
    End Sub
    'TWRP Install
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox11.Image = My.Resources._0
        Dim result1 As DialogResult = MessageBox.Show("If your device is still locked, this process will wipe ALL your data. Do you want to continue?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            PictureBox11.Image = My.Resources._50
            Shell("CMD.exe /C adb reboot bootloader & cd C:\RobinToolkit\ADB & fastboot -i 0x2c3f oem unlock & fastboot -i 0x2c3f flash recovery twrp.img", 0)
            PictureBox11.Image = My.Resources._100
            MessageBox.Show("Finished!")
            Shell("CMD.exe /C fastboot reboot")
        End If
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim result1 As DialogResult = MessageBox.Show("Your Robin will be wiped, do you want to continue?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Shell("CMD.exe /C adb reboot bootloader & fastboot -i 0x2c3f oem unlock", 0)
            MessageBox.Show("Finished!")
            Shell("CMD.exe /C fastboot -i 0x2c3f reboot", 0)
        End If
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim result1 As DialogResult = MessageBox.Show("Your Robin will be wiped, do you want to continue?",
                              "Important Question",
                              MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Shell("CMD.exe /C adb reboot bootloader & fastboot -i 0x2c3f oem lock", 0)
            MessageBox.Show("Finished!")
            Shell("CMD.exe /C fastboot -i 0x2c3f reboot", 0)
        End If
    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        BackgroundWorker2.RunWorkerAsync()
    End Sub
    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        If Not File.Exists("C:\RobinToolkit\ADB\system.img") Then
            MessageBox.Show("Don't close the program till until you get a downloaded window!")
            My.Computer.Network.DownloadFile(
  "http://daavm.com/wp-content/uploads/2016/04/system.part03.rar",
  "C:\RobinToolkit\ADB\system.part03.rar", "", "", True, 2000, True)
            My.Computer.Network.DownloadFile(
  "http://daavm.com/wp-content/uploads/2016/04/system.part04.rar",
  "C:\RobinToolkit\ADB\system.part04.rar", "", "", True, 2000, True)
            My.Computer.Network.DownloadFile(
  "http://daavm.com/wp-content/uploads/2016/04/system.part02.rar",
  "C:\RobinToolkit\ADB\system.part02.rar", "", "", True, 2000, True)
            My.Computer.Network.DownloadFile(
  "http://daavm.com/wp-content/uploads/2016/04/system.part01.rar",
  "C:\RobinToolkit\ADB\system.part01.rar", "", "", True, 2000, True)
            My.Computer.Network.DownloadFile(
  "http://daavm.com/wp-content/uploads/2016/04/system.part05.rar",
  "C:\RobinToolkit\ADB\system.part05.rar", "", "", True, 2000, True)
            My.Computer.Network.DownloadFile(
  "http://daavm.com/wp-content/uploads/2016/04/system.part06.rar",
  "C:\RobinToolkit\ADB\system.part06.rar", "", "", True, 2000, True)
            My.Computer.Network.DownloadFile(
  "http://daavm.com/wp-content/uploads/2016/04/system.part07.rar",
  "C:\RobinToolkit\ADB\system.part07.rar", "", "", True, 2000, True)
            My.Computer.Network.DownloadFile(
  "http://daavm.com/wp-content/uploads/2016/04/system.part08.rar",
  "C:\RobinToolkit\ADB\system.part08.rar", "", "", True, 2000, True)
            My.Computer.Network.DownloadFile(
  "http://daavm.com/wp-content/uploads/2016/04/system.part09.rar",
  "C:\RobinToolkit\ADB\system.part09.rar", "", "", True, 2000, True)
            My.Computer.Network.DownloadFile(
  "http://daavm.com/wp-content/uploads/2016/04/system.part10.rar",
  "C:\RobinToolkit\ADB\system.part10.rar", "", "", True, 2000, True)
            My.Computer.Network.DownloadFile(
  "http://daavm.com/wp-content/uploads/2016/04/system.part11.rar",
  "C:\RobinToolkit\ADB\system.part11.rar", "", "", True, 2000, True)
            My.Computer.Network.DownloadFile(
  "http://daavm.com/wp-content/uploads/2016/04/system.part12.rar",
  "C:\RobinToolkit\ADB\system.part12.rar", "", "", True, 2000, True)
            If File.Exists("C:\RobinToolkit\ADB\system.part01.rar") Then
                If File.Exists("C:\RobinToolkit\ADB\system.part02.rar") Then
                    If File.Exists("C:\RobinToolkit\ADB\system.part03.rar") Then
                        If File.Exists("C:\RobinToolkit\ADB\system.part04.rar") Then
                            If File.Exists("C:\RobinToolkit\ADB\system.part05.rar") Then
                                If File.Exists("C:\RobinToolkit\ADB\system.part06.rar") Then
                                    If File.Exists("C:\RobinToolkit\ADB\system.part07.rar") Then
                                        If File.Exists("C:\RobinToolkit\ADB\system.part08.rar") Then
                                            If File.Exists("C:\RobinToolkit\ADB\system.part09.rar") Then
                                                If File.Exists("C:\RobinToolkit\ADB\system.part10.rar") Then
                                                    If File.Exists("C:\RobinToolkit\ADB\system.part11.rar") Then
                                                        If File.Exists("C:\RobinToolkit\ADB\system.part12.rar") Then
                                                            Shell("CMD.exe /C cd C:\RobinToolkit\ADB\ & unrar e system.part01.rar", , 1)
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If File.Exists("C:\RobinToolkit\ADB\system.img") Then
                MessageBox.Show("System image downloaded! Restart program to have system installation enabled")
            End If
        Else
            MessageBox.Show("You already have the system factory image downloaded!")
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Dim webAddress As String = "https://community.nextbit.com/t5/Tools/TOOL-Robin-Toolkit-Root-TWRP-rescue-device/m-p/13209"
        Process.Start("Chrome", webAddress)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Shell("CMD.exe /C cd C:\RobinToolkit\ADB\ & setup.exe")
    End Sub
End Class
