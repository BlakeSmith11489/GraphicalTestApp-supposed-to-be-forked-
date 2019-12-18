using System;
using System.Collections.Generic;

namespace GraphicalTestApp
{
    delegate void StartEvent();
    delegate void UpdateEvent(float deltaTime);
    delegate void DrawEvent();

    class Actor
    {
        public StartEvent OnStart;
        public UpdateEvent OnUpdate;
        public DrawEvent OnDraw;

        public bool Started { get; private set; } = false;

        public Actor Parent { get; private set; } = null;
        private List<Actor> _children = new List<Actor>();
        private List<Actor> _additions = new List<Actor>();
        private List<Actor> _removals = new List<Actor>();

        private Matrix3 _localTransform = new Matrix3();
        private Matrix3 _globalTransform = new Matrix3();

        public float X
        {
            get { return _localTransform.m13; }

            set
            {
                _localTransform.SetTranslation(value, Y, 1);
                UpdateTransform();
            }
        }

        public float XAbsolute
        {
            get { return _globalTransform.m13; }
        }
        public float Y
        {
            get { return _localTransform.m23; }

            set
            {
                _localTransform.SetTranslation(X, value, 1);
                UpdateTransform();
            }
        }

        public float YAbsolute
        {
            get { return _globalTransform.m23; }
        }

        public float GetRotationAbsolute()
        {
            return (float)Math.Atan2(_globalTransform.m21, _globalTransform.m11);
        }

        public float GetRotation()
        {
            return (float)Math.Atan2(_localTransform.m21, _localTransform.m11);
        }

        public void Rotate(float radians)
        {
            _localTransform.RotateZ(radians);
            UpdateTransform();
        }

        public float GetScale()
        {
            return 1;
        }

        public void Scale(float scale)
        {
            _localTransform.Scale(scale, scale, 1);
            UpdateTransform();
        }

        public float GetScaleAbsolute()
        {
            return 0;
        }

        public void AddChild(Actor child)
        {
            if (child.Parent != null)
            {
                return;
            }

            child.Parent = this;

            _additions.Add(child);
        }

        public void RemoveChild(Actor child)
        {
            _removals.Add(child);
        }

        public void UpdateTransform()
        {
            if (Parent != null)
            {
                _globalTransform = Parent._globalTransform * _localTransform;
            }
            else
            {
                _globalTransform = _localTransform;
            }
            foreach (Actor child in _children)
            {
                child.UpdateTransform();
            }
        }
        public virtual void Start()
        {
            OnStart?.Invoke();

            foreach (Actor child in _children)
            {
                child.Start();
            }

            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            UpdateTransform();

            OnUpdate?.Invoke(deltaTime);

            foreach (Actor a in _additions)
            {
                _children.Add(a);
            }

            _additions.Clear();

            foreach (Actor a in _removals)
            {
                _children.Remove(a);
            }

            _removals.Clear();

            foreach (Actor child in _children)
            {

                child.Update(deltaTime);
            }
        }

        public virtual void Draw()
        {
            OnDraw?.Invoke();

            foreach (Actor child in _children)
            {
                child.Draw();
            }
        }
    }
}
