namespace SmartGambler.Data
{
	internal class Bullet
	{
		private static Bullet instance;
		public static Bullet GetInstance()
		{
			if (instance == null) instance = new Bullet();
			return instance;
		}
		private Bullet() { }

		private int _count = 0;
		private int _really = 0;
		private int _lie = 0;

		public void SetCount(UpDownReset upDownReset)
		{
			switch (upDownReset)
			{
				case UpDownReset.UP:
					_count++;
					break;
				case UpDownReset.DOWN:
					_count--;
					break;
				case UpDownReset.RESET:
					_count = 0;
					break;
			}
			UpdateBullet(BulletEnum.Count, _count);
		}

		public void SetReally(UpDownReset upDownReset)
		{
			switch (upDownReset)
			{
				case UpDownReset.UP:
					_really++;
					break;
				case UpDownReset.DOWN:
					_really--;
					break;
				case UpDownReset.RESET:
					_really = 0;
					break;
			}
			UpdateBullet(BulletEnum.Really, _really);
		}

		public void SetLie(UpDownReset upDownReset)
		{
			switch (upDownReset)
			{
				case UpDownReset.UP:
					_lie++;
					break;
				case UpDownReset.DOWN:
					_lie--;
					break;
				case UpDownReset.RESET:
					_lie = 0;
					break;
			}
			UpdateBullet(BulletEnum.Lie, _lie);
		}

		public void Reset()
		{
			_count = _really = _lie = 0;
			UpdateBullet(BulletEnum.Count, _count);
			UpdateBullet(BulletEnum.Really, _really);
			UpdateBullet(BulletEnum.Lie, _lie);
		}

		public int GetCount() { return _count; }
		public int GetReally() { return _really; }
		public int GetLie() { return _lie; }

		// event
		public EventHandler<bulletArgs> UpdateDataEvent = delegate { };

		public class bulletArgs : EventArgs
		{
			public BulletEnum type;
			public int value;
		}
		public void UpdateBullet(BulletEnum _type, int _value)
		{
			UpdateDataEvent.Invoke(instance, new bulletArgs()
			{
				type = _type,
				value = _value,
			});
		}
		public enum BulletEnum
		{
			Count = 0,
			Really = 1,
			Lie = 2,
		}
		public enum UpDownReset
		{
			UP = 0,
			DOWN = 1,
			RESET = 2,
		}
	}
}
