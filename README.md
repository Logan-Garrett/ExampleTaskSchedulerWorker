
# The Below can install a Task to the Windows Task Scheduler.

Example 1
<pre>
schtasks /create /tn "MyTask" /tr "cmd /c start /min notepad.exe" /sc daily /st 09:00 /rl highest
</pre>

Example 2
<pre>
# Define the action (e.g., run Notepad)
$action = New-ScheduledTaskAction -Execute "notepad.exe"

# Define the trigger (e.g., at logon)
$trigger = New-ScheduledTaskTrigger -AtLogOn

# Define the settings, including making it Hidden
$settings = New-ScheduledTaskSettingsSet -Hidden

# Register the task
Register-ScheduledTask -TaskName "MyHiddenTask" -Action $action -Trigger $trigger -Settings $settings
</pre>

# Explained

## Install
schtasks	The command-line utility to create/manage scheduled tasks.
/create	Tells schtasks that you want to create a new task.
/tn "MyTask"	Sets the task name to MyTask. You’ll see this in Task Scheduler.
/tr "cmd /c start /min notepad.exe"	Specifies the task to run.
- cmd /c runs a command and exits.
- start opens a new window.
- /min starts the program minimized, making it less intrusive (not fully hidden, but not visible upfront).
- notepad.exe is the program to run.
/sc daily	The schedule: run the task daily.
/st 09:00	The start time: 9:00 AM. Must be in 24-hour format (HH:mm).
/rl highest	Runs the task with highest privileges (like admin), required for some programs or hidden behaviors. (Can be run under a service account)

## Start
schtasks /run /tn "MyTask" (Does Run At that exact Moment.)

## Stop
schtasks /end /tn "MyTask"

## Enable Task
schtasks /change /tn "MyTask" /disable

## Disable Task
schtasks /change /tn "MyTask" /enable

## UnInstall
schtasks /delete /tn "MyTask" /f

