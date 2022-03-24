﻿using Common.Constants;
using Common.Cryptography;
using Common.Interfaces;
using Common.Structs;

namespace Common.Extensions;

public static class CharacterExtensions
{
    public static uint GetDisplayId(this ICharacter character)
    {
        if (CharacterData.DisplayIds.TryGetValue((Races)character.Race, out var ids))
            return ids[character.Gender];

        return CharacterData.DisplayIds[Races.HUMAN][character.Gender];
    }

    public static uint GetFactionTemplate(this ICharacter character)
    {
        if (CharacterData.FactionTemplates.TryGetValue((Races)character.Race, out var id))
            return id;

        return CharacterData.FactionTemplates[Races.HUMAN];
    }

    public static void SetDefaultValues(this ICharacter character)
    {
        bool male = character.Gender == 0;

        // TODO hardcoded values
        bool hunterFocus = Authenticator.ClientBuild < 3807 || Authenticator.ClientBuild > 12340;

        // scale
        character.Scale = 1f;
        if ((Races)character.Race == Races.TAUREN)
            character.Scale = male ? 1.35f : 1.25f; // tauren male, tauren female

        // display id
        character.DisplayId = character.GetDisplayId();

        // power type
        switch ((Classes)character.Class)
        {
            case Classes.WARRIOR:
                character.PowerType = (byte)PowerTypes.RAGE;
                break;
            case Classes.ROGUE:
                character.PowerType = (byte)PowerTypes.ENERGY;
                break;
            case Classes.HUNTER:
                character.PowerType = (byte)(hunterFocus ? PowerTypes.FOCUS : PowerTypes.MANA);
                break;
            case Classes.DEATHKNIGHT:
                character.PowerType = (byte)PowerTypes.RUNIC;
                break;
            default:
                character.PowerType = (byte)PowerTypes.MANA;
                break;
        }
    }

    public static IPacketWriter BuildMessage(this ICharacter character, IPacketWriter message, string text)
    {
        uint build = Authenticator.ClientBuild;

        // System Message
        byte messageType = 0x9;
        if (build >= 4937)
            messageType = 0xA;
        if (build >= 8089)
            messageType = 0;

        message.WriteUInt8(messageType);
        message.WriteUInt32(0); // Language: General
        message.WriteUInt64(0);

        if (build >= 6577)
        {
            message.WriteUInt32(0);
            message.WriteUInt64(0);
        }

        if (build >= 4062)
            message.WriteInt32(text.Length + 1); // string length

        message.WriteString(text);
        message.WriteUInt8(0); // chat flag (gm, dnd etc.)
        return message;
    }

    public static IPacketWriter BuildForceSpeed(this ICharacter character, IPacketWriter writer, float modifier)
    {
        modifier *= 7f; // default speed

        if (Authenticator.ClientBuild < 4062)
            modifier = Math.Max(modifier, 56f); // alpha clients crash, other clients are limited

        writer.WriteFloat(modifier);
        return writer;
    }

    public static void Teleport(this ICharacter character, Location loc, ref IWorldManager manager)
    {
        character.Teleport(loc.X, loc.Y, loc.Z, loc.O, loc.Map, ref manager);
    }

    public static void Demorph(this ICharacter character)
    {
        character.DisplayId = character.GetDisplayId();
    }

}