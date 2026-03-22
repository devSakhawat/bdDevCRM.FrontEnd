// login.ts
(function () {
  'use strict';

  /* ── Interfaces ───────────────────────────── */
  interface LoginResponse {
    success: boolean;
    message?: string;
    redirectUrl?: string;
  }

  /* ── DOM refs ─────────────────────────────── */
  const form = document.getElementById('loginForm') as HTMLFormElement | null;
  const loginIdEl = document.getElementById('loginId') as HTMLInputElement | null;
  const passwordEl = document.getElementById('password') as HTMLInputElement | null;
  const rememberEl = document.getElementById('rememberMe') as HTMLInputElement | null;
  const btnLogin = document.getElementById('btnLogin') as HTMLButtonElement | null;
  const alertBox = document.getElementById('loginAlert') as HTMLElement | null;
  const alertMsg = document.getElementById('loginAlertMsg') as HTMLElement | null;
  const pwdToggle = document.getElementById('pwdToggle') as HTMLElement | null;
  const pwdIcon = document.getElementById('pwdToggleIcon') as HTMLElement | null;

  /* ── Password visibility toggle ──────────── */
  pwdToggle?.addEventListener('click', () => {
    if (!passwordEl) return;
    const isText = passwordEl.type === 'text';
    passwordEl.type = isText ? 'password' : 'text';
    if (pwdIcon) {
      pwdIcon.className = isText
        ? 'fa-regular fa-eye'
        : 'fa-regular fa-eye-slash';
    }
  });

  /* ── Show / hide alert ────────────────────── */
  function showAlert(msg: string): void {
    if (alertMsg) alertMsg.textContent = msg;
    alertBox?.classList.add('show');
  }

  function hideAlert(): void {
    alertBox?.classList.remove('show');
  }

  /* ── Field validation ─────────────────────── */
  function validateField(input: HTMLInputElement | null, errorEl: HTMLElement | null, message: string): boolean {
    if (!input || !errorEl) return false;

    if (!input.value.trim()) {
      input.classList.add('is-invalid');
      errorEl.textContent = message;
      errorEl.classList.add('show');
      return false;
    }
    input.classList.remove('is-invalid');
    errorEl.classList.remove('show');
    return true;
  }

  /* ── Loading state ────────────────────────── */
  function setLoading(loading: boolean): void {
    if (!btnLogin) return;
    btnLogin.disabled = loading;
    btnLogin.classList.toggle('loading', loading);
  }

  /* ── Form submit ──────────────────────────── */
  form?.addEventListener('submit', async (e: Event) => {
    e.preventDefault();
    hideAlert();

    const loginIdError = document.getElementById('loginIdError');
    const passwordError = document.getElementById('passwordError');

    /* Client-side validation */
    const v1 = validateField(loginIdEl, loginIdError, 'Please enter your username.');
    const v2 = validateField(passwordEl, passwordError, 'Please enter your password.');

    if (!v1 || !v2) return;

    setLoading(true);

    /* CSRF token */
    const tokenInput = document.querySelector('input[name="__RequestVerificationToken"]') as HTMLInputElement | null;
    const token = tokenInput?.value;

    try {
      const res = await fetch('/Account/Login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'X-Requested-With': 'XMLHttpRequest',
          'RequestVerificationToken': token ?? ''
        },
        body: JSON.stringify({
          loginId: loginIdEl?.value.trim(),
          password: passwordEl?.value,
          rememberMe: rememberEl?.checked
        }),
        credentials: 'same-origin'
      });

      const data: LoginResponse = await res.json();

      if (data.success) {
        /* Redirect to dashboard */
        window.location.href = data.redirectUrl || '/Home/Index';
      } else {
        showAlert(data.message || 'Invalid username or password.');
        setLoading(false);
        if (passwordEl) {
          passwordEl.value = '';
          passwordEl.focus();
        }
      }

    } catch (err) {
      showAlert('Connection error. Please try again.');
      setLoading(false);
    }
  });

  /* ── Clear errors on input ────────────────── */
  [loginIdEl, passwordEl].forEach(input => {
    if (!input) return;
    input.addEventListener('input', () => {
      input.classList.remove('is-invalid');
      const errId = input.id + 'Error';
      const errEl = document.getElementById(errId);
      if (errEl) errEl.classList.remove('show');
      hideAlert();
    });
  });

  /* ── Enter key on username → focus password ─ */
  loginIdEl?.addEventListener('keydown', (e: KeyboardEvent) => {
    if (e.key === 'Enter') {
      e.preventDefault();
      passwordEl?.focus();
    }
  });

  /* ── Forgot password ──────────────────────── */
  document.getElementById('forgotPasswordLink')?.addEventListener('click', (e: Event) => {
    e.preventDefault();
    alert('Please contact your system administrator to reset your password.');
  });

})();