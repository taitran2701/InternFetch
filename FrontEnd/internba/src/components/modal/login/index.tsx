import * as React from "react";
import styles from "./index.module.scss";
export interface IModalLoginProps {
  show: boolean;
  onClose: () => void;
}

export default function ModalLogin(props: IModalLoginProps) {
  if (!props.show) return null;
  return (
    <div className={styles.modal} onClick={props.onClose}>
      <div className={styles.modelContent} onClick={(e) => e.stopPropagation()}>
        <div className={styles.modalHeader}>
          <h4 className={styles.modalHeader}>Modal title</h4>
        </div>
        <div className={styles.modalBody}>
          <input
            placeholder="username"
            type="text"
            className={styles.loginInput}
          />
          <input
            placeholder="password"
            type="text"
            className={styles.loginInput}
          />
          <button className={styles.btnLogin}> Log In</button>
          <a href="#" className={styles.loginForgot}>
            Forgot Password?
          </a>
          <button className={styles.btnNewAccount}>Create new account</button>
        </div>
      </div>
    </div>
  );
}
