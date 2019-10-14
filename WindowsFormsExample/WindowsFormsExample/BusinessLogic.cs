using System;
using System.Threading;

namespace WindowsFormsExample
{
    class BusinessLogic
    {
        private Delegate UpdateUI;

        public BusinessLogic(Delegate updateUI)
        {
            this.UpdateUI = updateUI;
        }

        public void ProcessItems(int totalItems, int processingTime)
        {
            for (int i = 1; i <= totalItems; i++)
            {
                this.UpdateUI.DynamicInvoke(i);
                Thread.Sleep(processingTime); // This simulates doing some cpu intensive stuff
            }
        }
    }
}
