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
                    await view.RotateToAsync(15, 200, Easing.Linear);
                    await view.RotateToAsync(-15, 200, Easing.Linear);
                }
                await view.RotateToAsync(0, 200, Easing.Linear);
                return;
            case AnimationType.Fade:
                view.Opacity = 0;
                await view.FadeToAsync(1, duration);
                return;
            case AnimationType.Scale:
                await view.ScaleToAsync(1.5, duration);
                await view.ScaleToAsync(1, duration);
                return;
            case AnimationType.Rotate:
                await view.RotateToAsync(360, duration);
                view.Rotation = 0;
                return;
        }
    }
}
