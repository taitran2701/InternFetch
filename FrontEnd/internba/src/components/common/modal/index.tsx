import * as React from "react";
import styles from "./index.module.scss";
export interface IModalProps {
  show: boolean;
  onClose: () => void;
  checkUserLogin: () => void;
  title: string;
  children: React.ReactNode;
}

interface IUser {
  username: string;
  password: string;
  email: string;
  avater: string;
  id: string;
}

export default function Modal(props: IModalProps) {
  const { onClose, title, children } = props;

  if (!props.show) return null;

  return (
    <div className={styles.modal} onClick={onClose}>
      <div className={styles.modelContent} onClick={(e) => e.stopPropagation()}>
        <div className={styles.modalHeader}>
          <h3 className={styles.logoLogin}>{title}</h3>
        </div>
        <div className={styles.modalBody}>{children}</div>
      </div>
    </div>
  );
}
