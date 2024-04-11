using UnityEngine;
using Game.Data;

namespace Game
{

    public interface IMagazine : IInitialization<SOMagazine>, IUpdater
    {
        public IModel Model { get; }
        public SOMagazine SOMagazine { get; }
        public float Amount { get; }
        public bool Empty { get; }
        public bool CanUse { get; }

        public SOAmmo Get();
        public void Recover();
        public void Reloading();
    }

    public class Magazine : IMagazine
    {
        public IModel Model { get; private set; }
        public SOMagazine SOMagazine { get; private set; }
        public float Amount => _model.Data.Amount.Value;
        public bool Empty => _model.Data.Amount.Value <= 0;
        public bool CanUse { get; private set; } = true;

        private ModelMagazine _model;
        private float _timeRelFul;
        private float _timeRelOne;

        public void Init(SOMagazine data)
        {
            SOMagazine = data;
            _model = new ModelMagazine();
            _model.Set(data.Model.Data);
            Model = _model;
        }

        public virtual SOAmmo Get()
        {
            SOAmmo ammo = null;
            if (!Empty && CanUse)
            {
                ammo = SOMagazine.SOAmmo;
                _model.Data.Amount.Value -= 1;
                _model.Data.Amount.Value = Mathf.Clamp(_model.Data.Amount.Value, 0, _model.Data.Amount.Max);
            }
            return ammo;
        }

        public void Recover()
        {
            _model.Data.Amount.Value += 1;
            _model.Data.Amount.Value = Mathf.Clamp(_model.Data.Amount.Value, 0, _model.Data.Amount.Max);
        }

        public void Reloading()
        {
            CanUse = false;
            _model.Data.Amount.Value = 0;
            _timeRelFul = _model.Data.Reloading;
            _timeRelOne = _model.Data.Reloading / _model.Data.Amount.Max;
        }

        public void OnUpdate()
        {
            if (!CanUse & _timeRelFul > 0f)
            {
                _timeRelFul -= Time.deltaTime;
                if (_timeRelFul > 0f & _timeRelFul < (_timeRelOne * (_model.Data.Amount.Max - _model.Data.Amount.Value)))
                {
                    Recover();
                }
            }

            if (!CanUse & _timeRelFul <= 0f)
            {
                CanUse = true;
            }
        }
    }
}