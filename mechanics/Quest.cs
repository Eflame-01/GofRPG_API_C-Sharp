using System;

namespace GofRPG_API
{
    public class Quest
    {
        public String QuestID{get; private set;}
        public String QuestTitle{get; private set;}
        public String QuestDescription{get; private set;}
        public Boolean IsMajor{get; private set;}
        public Boolean IsCompleted{get; private set;}

        public Quest(String id, String title, String description, Boolean isMajor, Boolean isCompleted)
        {
            QuestID = id;
            QuestTitle = title;
            QuestDescription = description;
            IsMajor = isMajor;
            IsCompleted = isCompleted;
        }

    }
}