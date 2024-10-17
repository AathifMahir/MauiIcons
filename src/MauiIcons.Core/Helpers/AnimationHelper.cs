namespace MauiIcons.Core.Helpers;
internal static class AnimationHelper
{
    internal static async Task AnimateIconAsync(AnimationType type, View view, uint duration)
    {
        switch (type)
        {
            case AnimationType.None:
                return;
            case AnimationType.Wiggle:
                uint maxDuration = Math.Max(duration, 200);
                int noOfTimes = (int)(maxDuration / 200);
                for (int i = 0; i < noOfTimes; i++)
                {
                    await view.RotateTo(15, 200, Easing.Linear);
                    await view.RotateTo(-15, 200, Easing.Linear);
                }
                await view.RotateTo(0, 200, Easing.Linear);
                return;
            case AnimationType.Fade:
                view.Opacity = 0;
                await view.FadeTo(1, duration);
                return;
            case AnimationType.Scale:
                await view.ScaleTo(1.5, duration);
                await view.ScaleTo(1, duration);
                return;
            case AnimationType.Rotate:
                await view.RotateTo(360, duration);
                view.Rotation = 0;
                return;
        }
    }
}
