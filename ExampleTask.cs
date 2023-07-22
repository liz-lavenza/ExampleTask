using MelonLoader;
using TasksLib;

namespace ExampleTask
{
    public class ExampleTaskMod : MelonMod
    {
        public override void OnLateInitializeMelon()
        {
            TasksLibMod.AddTask(new WaifuTask() {
                StudentID = 40,
                Description = "Mai Waifu wants some soda, but she's banned from using the vending machines. She'll give you $5 to buy one for her.",
                Icon = "TaskSodaCan.png",
                Lines = new string[6] {
                    "Don't worry about it, Yan-chan, I'll be fine.", // player rejection
                    "Well, see, I really want some soda...", // task introductions
                    "But after the last time I tried to break into the vending machine, they won't even let me near it!",
                    "Could you get some for me? I'll give you money!",
                    "Here, this five dollar bill should cover it.", // player accept
                    "Thank you so much, Yan-chan! Keep the change.", // task completed
                }
            });
        }
        class WaifuTask : YandereTask
        {
            protected override void OnMarkActive()
            {
                taskman.Yandere.Inventory.Money += 5;
                taskman.Yandere.Inventory.UpdateMoney();
            }
            public override bool IsComplete()
            {
                return taskman.Yandere.Inventory.Soda;
            }
            public override void OnTurnedIn()
            {
                taskman.Yandere.Inventory.Soda = false;
            }
        }
    }
}
