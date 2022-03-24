using Common.Interfaces;
using Common.Network;
using TaidanaKage.Kek;

namespace WorldServer.Packets;

public class HandlerDefinitions
{
    public static void InitializePacketHandler()
    {
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_VERIFY_CONNECTIVITY, HandleAuthChallenge);

        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_AUTH_SESSION, Program.Sandbox.AuthHandler.HandleAuthSession);
        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_LOGOUT_REQUEST, Program.Sandbox.AuthHandler.HandleLogoutRequest);
        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_CHAR_ENUM, Program.Sandbox.CharHandler.HandleCharEnum);
        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_CHAR_CREATE, Program.Sandbox.CharHandler.HandleCharCreate);
        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_CHAR_DELETE, Program.Sandbox.CharHandler.HandleCharDelete);
        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_PING, Program.Sandbox.WorldHandler.HandlePing);
        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_PLAYER_LOGIN, Program.Sandbox.WorldHandler.HandlePlayerLogin);
        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_QUERY_TIME, Program.Sandbox.WorldHandler.HandleQueryTime);
        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_NAME_QUERY, Program.Sandbox.CharHandler.HandleNameCache);

        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_WORLD_TELEPORT, Program.Sandbox.WorldHandler.HandleWorldTeleport);
        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_AREATRIGGER, Program.Sandbox.WorldHandler.HandleAreaTrigger);
        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_ZONEUPDATE, Program.Sandbox.WorldHandler.HandleZoneUpdate);

        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_MESSAGECHAT, Program.Sandbox.CharHandler.HandleMessageChat);
        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_TEXT_EMOTE, Program.Sandbox.CharHandler.HandleTextEmote);

        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_START_FORWARD, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_START_BACKWARD, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_STOP, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_START_STRAFE_LEFT, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_START_STRAFE_RIGHT, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_STOP_STRAFE, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_JUMP, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_START_TURN_LEFT, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_START_TURN_RIGHT, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_STOP_TURN, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_START_PITCH_UP, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_START_PITCH_DOWN, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_STOP_PITCH, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_SET_RUN_MODE, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_SET_WALK_MODE, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_START_SWIM, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_STOP_SWIM, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_SET_FACING, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_SET_PITCH, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_ROOT, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_UNROOT, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_HEARTBEAT, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_FALL_LAND, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_START_ASCEND, Program.Sandbox.CharHandler.HandleMovementStatus);
        PacketManager.DefineOpcodeHandler(Opcodes.MSG_MOVE_STOP_ASCEND, Program.Sandbox.CharHandler.HandleMovementStatus);

        PacketManager.DefineOpcodeHandler(Opcodes.CMSG_STANDSTATECHANGE, Program.Sandbox.CharHandler.HandleStandState);
    }

    private static void HandleAuthChallenge(ref IPacketReader packet, ref IWorldManager manager)
    {
        Program.Sandbox.AuthHandler.HandleAuthChallenge();
    }
}