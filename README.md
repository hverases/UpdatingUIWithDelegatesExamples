# Updating UI with delegates examples

Despite I'm focused in developing .net stack web applications, a few years ago I was requested at work to build a desktop application to do some batch processing. I already knew a bit of Windows Forms and WPF, but I had some trouble when updating UI (to show progress for example) while the application was doing heavy CPU-bound stuff.

The answer is that you can't block the main thread and update UI at the same time. When the application execute UI updating instructions, these updates are added to a message queue. This queue is processed in the main thread, so if you block this thread with a long time running operation, these UI updates won't be processed until it finishes. You should assign your heavy workload to a secondary thread to keep the main thread free in order to do updates and keep it responsive to user interactions.

I think that delegates are a great tool to do these updates from the business logic class and decouple it from the UI code. So, if you want to migrate the UI from Windows Forms to WPF, you can keep your business logic class unchanged.

Delegates are something like pointer to function in C language, so you can call an UI updating function from your business logic class and don't worry about how UI update is done, as long as parameters match, of course. In addition, delegates are thread safe, so you don't have to worry about calling UI updating functions from a secondary thread, at least in Windows Forms.

This thread safe feature of delegates is not enough in WPF applications and you must use a dispatcher and invoke an anonymous function to do UI updates from another thread. In spite of that, you can implement this on the UI code and keep business logic decoupled from UI.

I coded two examples, one using Windows Forms and the other one using WPF to show how delegates can be used. **Thread.sleep** is used as a placeholder to simulate long time running operations.