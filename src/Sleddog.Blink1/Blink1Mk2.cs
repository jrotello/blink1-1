using System;
using System.Drawing;
using Sleddog.Blink1.Commands;
using Sleddog.Blink1.Internal;

namespace Sleddog.Blink1
{
    public class Blink1Mk2 : Blink1, IBlink1Mk2, IDisposable
    {
        public new bool EnableGamma
        {
            get { return base.EnableGamma; }
            set { }
        }

        internal Blink1Mk2(Blink1CommandBus commandBus)
            : base(commandBus, 32)
        {
        }

        public bool Fade(Color color, TimeSpan fadeDuration, LEDPosition ledPosition)
        {
            var command = new FadeToColorCommand(color, fadeDuration, ledPosition);

            return commandBus.SendCommand(command);
        }

        public bool Play(ushort startPosition, ushort endPosition, ushort count)
        {
            var command = new PlayPresetCommand(startPosition, endPosition, count);

            return commandBus.SendCommand(command);
        }

        public bool SavePresets()
        {
            var command = new SavePresetsCommand();

            return commandBus.SendCommand(command);
        }

        public bool EnabledInactivityMode(TimeSpan waitDuration, bool maintainState, ushort startPosition,
            ushort endPosition)
        {
            var command = new EnableInactivityModeCommand(waitDuration, maintainState, startPosition, endPosition);

            return commandBus.SendCommand(command);
        }

        public PlaybackStatus ReadPlaybackStatus()
        {
            var query = new ReadPlaybackStateQuery();

            return commandBus.SendQuery(query);
        }
    }
}