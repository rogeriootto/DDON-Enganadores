public class NpcExtendedFacility : INpcExtendedFacility
{
    public NpcExtendedFacility()
    {
        NpcId = NpcId.Morgan;
    }

    public override void GetExtendedOptions(DdonGameServer server, GameClient client, S2CNpcGetNpcExtendedFacilityRes result)
    {
        var quest = QuestManager.GetQuestByQuestId(QuestId.EpitaphRoadMegadosysRegion);
        if (client.Character.CompletedQuests.ContainsKey(quest.QuestId) || (client.QuestState.IsQuestActive(quest.QuestScheduleId) && client.QuestState.GetQuestState(quest.QuestScheduleId).Step > 2))
        {
            result.ExtendedMenuItemList.Add(new CDataNpcExtendedFacilityMenuItem() { FunctionClass = NpcFunction.WarMissions, FunctionSelect = NpcFunction.HeroicSpiritSleepingPath });
        }
    }
}

return new NpcExtendedFacility();
