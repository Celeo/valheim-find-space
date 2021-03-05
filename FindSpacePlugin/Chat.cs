using HarmonyLib;
using System.Collections.Generic;
using System.Linq;

namespace FindSpace
{
    [HarmonyPatch(typeof(Chat), "InputText")]
    public class HookChatInputText
    {
        static bool Prefix(Chat __instance)
        {
            string text = __instance.m_input.text;
            if (text == "/findspace")
            {
                SearchNearbyForSpace();
                return false;
            }
            return true;
        }

        static void SearchNearbyForSpace()
        {
            var pieces = new List<Piece>();
            Piece.GetAllPiecesInRadius(Player.m_localPlayer.transform.position, 10f, pieces);
            pieces
                .Where(p => p.GetComponent<Container>())
                .Where(p => p.GetComponent<Container>().GetInventory().GetEmptySlots() > 0)
                .ToList()
                .ForEach(p => HighlightPiece(p));
        }

        static void HighlightPiece(Piece piece)
        {
            var component = piece.GetComponent<WearNTear>();
            if (component)
            {
                component.Highlight();
            }
        }
    }
}
