import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUserGroup } from "@fortawesome/free-solid-svg-icons";
import {faImage} from "@fortawesome/free-solid-svg-icons";
import { faShield } from "@fortawesome/free-solid-svg-icons";
import { faUserAstronaut } from "@fortawesome/free-solid-svg-icons";
import sidebar from "./sidebar.module.scss";
import Button from "./button.module.scss";
import React from "react";

function Sidebar() {
  return (
    <React.Fragment>
      <div className={sidebar.sidebar}>
        <div className={sidebar.leftbar}>
          <div className={sidebar.shortCut}>
            <button className={Button.button}>
              <div className={sidebar.itemWrapper}>
                <img src="https://lh3.googleusercontent.com/a/AItbvmkWzx51cEWuN7GcyaMaW1dmhWLEfHKtbal8Tclg=s96-c" alt="" className={sidebar.sidebarItemIcon} />
                <span className={sidebar.sidebarItemDesc}>Tai tran</span>
              </div>
            </button>
            <button className={Button.button}>
              <div className={sidebar.itemWrapper}>
                <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACQAAAAkCAYAAADhAJiYAAAFRklEQVR4Ae2WA9AkOxDHk5lZn+1n27Zt27Zt28bZtm3btr/DcmbSL6n5V2pe6vbDoXhd1ZWOOr90enuW7aLslb3Cd8caCO1pIG7YFpSHAASUdhcYL2scEM5BbdbdzlLV7ua2c4QaJN+bybIlTeffXKe17HoAK6/QTgEBJnJQp/SvLJq4hxEmOZcmBW7dbNP516ceVRagsJ/ZqoUS1C8rmlYxGLTWvn/Mv4TZEsYPjiNBjHxiqk+yr+bUmhCAde6550a/nDPplR+Xzpr048q5G3+QreqrcZxZNCC8jOhED2yzvYuMzsWsNClk+y24tdL1ylJgn8+b/Es0Hr9XeSJSEQ3curncPy8ddOxjiCbtKEpOsSeDRpgVOUhFhvRzwQsWqHHizkHwJZ7q0PRQKxG/2yPCUYCSHR6P3fNs53bff3vdzTPMH0NZQDoPSNj1lEcinTuw4Y2U7dTDkznJ+g1OdYVvBQ6C9WgVgpVoUPsUOTUH0cQ5jMoGglChsJQ50UODXQLHKJsCQAXrFZbgiW0eset7BAjkuLIYoJhtNzCSHVI+IBK5bZN5osaheoQTE4iQIAq85jJT4Jxt21yyJFa7Fo4ngDG8EJfzmxQ8N6HKC+TnRrT9NnHBY9dKO0FBMugnwN2z2eEtv8OJYlqPvmPOemb/bdxildU8QHA7f9uMPgNGV7AOgRw1SGqq4QcT74o1POpTwVg0dCW1oJBfOf3VlW+d0IJJMAzHHhrQ+eEa++37MTNk0+Ilr/9x4XW/STNtFFMqq3pbSNKY1CpS69Z7+N8rmny/ts++v6XXKFV2vYebX6HmpFZVEVTKsP72jv8+/PSMUZOenz9+69PTRk1SfaytLDVqFM7y1SEDLA5HEcy7+KXk0Ipw/QJcDPt9qXlEUbW+UbWL/sp4kWhxOPDQwomysQZirC8wiLFWGAmtbV4Exlba6OOFV1iJGrcyO3oq53YdYizGUX3Vfs6sPJG3jvmFsf7WVe1OOXbChpr7H/AEjzinMm7VUdEM1pPicBmJdb6bH7Nt1frv211yw9gdfJSJwwi3dsPnh+9nNTqmKbcjp/6fVxdFtLgYpFr1NB11zHIei+V1jdLCUb+IpGkJL5NpOrtd+5fGffJTSRiKmzB1nx58SHTfkwfJbm1AmNEFjTFHwaHRmMuOP3UeSyRdPa+jaiSDl8m1aXX8effrHDSA7BqnXJZMXd92DFnOYVy7g+DGxjgwwQfYZOUsO/7suWDGKlCh1R7yGzY+3PHsq5ri+YiHoJwGby1+1ErV+U52QycSLq+B4BTjsJWEDzvg2KWsTuON4WF9mfBzkudN6HDMuefi1yqc0HNFuFP1JiYYqrAZIkQnZIdFJzoP9q9fVp3VbLwBG5A7uCgJoW1uW4eFa5ITjpDsHk4+eriphjO+3MgOyQ/n2EOw05vjzBUCNIgKCdNmlmUlQkAsHCGLhFUDJQIHiFBSIjacNK+0kc/YowS26zvMZxSOHvbBNX4IIpudbH5cuYYSfomErUZEOkmVjYQO/x8Csx5HIEiPOTGPubLViSxCeSaEavMinZu4vu/gF5DQOjI2qmeq3nNLv+XJGvewogKScojYtrrV2u8Pfh+boFoENC81B3WR1HqhV9LlvneqXvGLx5N1rmKWXYcZvwhcEH2IuUb46yi9pmdJ57s+k73tuL0JRADyoPiuIXegCi4OjaJvsYqJgOMCbu9izITRUIaSE6L34QihxEeyYqJ9hZRKATKVOQati5YbWqaYNzdaKnNPkW+ZqWyngKDGWHmEuHlgxUHKvnVFoHg5x3YFrELyH4+psE5bV4QBAAAAAElFTkSuQmCC" alt="" className={sidebar.sidebarItemIcon} />
                <span className={sidebar.sidebarItemDesc}>Friends</span>
              </div>              
            </button>
            <button className={Button.button}>
              <div className={sidebar.itemWrapper}>
                <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACQAAAAkCAYAAADhAJiYAAADM0lEQVR4AWIYbICRJLWUAUDtVQFiRwxEM9lzpVgdLVJ3F6SO+xU7vO7urnhdkbrg1mLFpe4tUnd3/bZpBobu28vns+ylC4+ZTOYnb0eyPyaJU1lSAjAmT0RMckIuEW0RiNRgT0IkFBREmjRpICQzq8vEmhmVE9ZXUuUkIt02tGZjERJLLbuIbGkj9fZnmDm179eZ1ccfnPuFpEAmJqQtym9327GtNqiebZgI8WYkr01AROYM2xT4sZ3Uj/D3jjE3m5fYqZyQQkLJakhQXhHUNOUpABIRMUMSLRNtHsq8EX9GeVl9kx2utMhbUNoaIvYpUHnbfxurSKJutEUxUhJNY3Rb2Y/Sd5mAo4OR4epkXZGOpc7oOEmpIyEYX7NVXZajAGoF3hpsDgFDLEHXbs2mJKTyVAZvjh3GwDQxJHKkorFmwi6XtDVEORVEmxqCjlJCBMdaIkVO5CBdrYuQTVmUCqJoQ60Vy4JRUEPFI2eAR+sJqQDbWHTY0EmZHAOxGvJFSGpINgQioOuo2xSmieKHpj9CuqxFfYiU4sb6MUgGiXtOmXSVctMFemyMHaeUb0Ja3hhqwkmfbIw+8brzSIisG5zQRpOQ0VFtYUpZUvzEVl5riILYZ0NJzYQYAQ11BFGC1HrtMugc2JCKnN5iK4iP+HuuIfi4Qidh8eLp7fz9kFT6Pxil1WFD6CyDX3an4/7bwRiPCuo6qhlFTvfJ4zVlEAFIH6bOaB35ucv4JaSUtD28dewLn+Ai4jVlxf8FUloOHk5qJYcd54KSs/BNyDDyBG7kuHz/mnl+hLXGys7N1qG+9Hqly0unv6ibn98yr/acfbRwxP6LQ7YyWGcbz6VdVye8m/+A4a8fmZf7zz9aNmzfxQEb7rw4+cIavzNYZxvPsQ/7wjo/Skcn2X2+3KJhzrB7BxaPevlhxtDr+wd1nNLb2tpatLGos6i2qGSIXidzbdl3+tBr+xaNevFxzvB7h3gtWVNj8pNepZFUFdRbTlCwCAX4aEFgUS5QcmP9A1dpI0hc1IYBC2iwF1gC8DHiXxBkwJ53fpM8QnEJuknQMehPrj/KBITcOdCLkzCuX+nfoo7PXwWnLg9eMYw8AAAAAElFTkSuQmCC" alt="" className={sidebar.sidebarItemIcon} />
                <span className={sidebar.sidebarItemDesc}>Friends</span>
              </div>              
            </button>
            <button className={Button.button}>
              <div className={sidebar.itemWrapper}>
                <img src="data:image/png;base64,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" alt="" className={sidebar.sidebarItemIcon} />
                <span className={sidebar.sidebarItemDesc}>Groups</span>
              </div>              
            </button>
            <button className={Button.button}>
              <div className={sidebar.itemWrapper}>
                <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAABmJLR0QA/wD/AP+gvaeTAAADRklEQVRoge1ZzWoUQRD+eiNogslB9BASiSePHnwEgyAIPkZeIRfBi0/gyTyJBxF8A0E8eVKyoOhFXHUVwpSH2Zrp/6rq3T1lC7Iz2zPd9VXVV9VdWWAjG7nc4qpPT989dnBnIBwAwP1Hd3SrEkB8440ltxQ+uH4xx8Of7/Hg7hFefJjj7acf00mHk6/Pjl+VVE1qOBy5lwxeBZoAIgKBRiv4j2/5g8IHRMBsaxuv9+7h1s4Wnh8fwQGHNHFnNbVXBFiHAcIS8IKnh6+Uf5CsSITZ5BqAX9jfvcqDt2sABQN6Lc53Y6BcoogOdGYJtVQNcFGoKfakgtc8RpWB3BSt1CNAXW/EsHrqQitFgnnJNLsVQgS6AYnzEK0WdD8Qs00rcgQGVFQEniiPBvIUoYLBEuRQFBHoATmudaH+BFCCI6aIAJqMFqgNKCvX8TpLkYGSFHy3iEChHrijqGh6aL5Pf9u1enJjf7u5AgHqJGYPRd5eQnG4kL/8CimEhQFusXqOIjcPdvS8zmCjPO/UoosAa4q43cxrYSe3iKKMssZaIo83NYfqd3K96KrQIpEDj5soktu+44CuhUJ8jKDhMmIw8jrr7XSy1Q7hNNp5pbRXXQy1wOtwnrCTG0Sm0LB6PmlVFNGCbrBELqNEYyInelIXS7yunZtaAqGIAC9NhioieZsKBmsghyIeJWr9wOpBW49y6hzg3bhOEYnX+QJA5bkKaegHNKUv4+3MO7WdXCvGjiyXyJ5mLUUyJXi82Cww9QM1itRAe69Fc/mSLwwaUZxGESVyiKaVIsuA9kV3lIj6gSpFGkFT+KEWZT9AYQXS8NobMx/2DNLYDyzH66y3yzZWRVdGASGR+dJAkXhvMcrS/QClX8JXCqCT0fX0A6MBYyLzReJ19FABuiUddP9W4SSmFFCqXAIdjiyZw0IEvIYmRWLktXhuakuGJfoBO6/z3qZW7ACaOrJV8LoAeh0RcAOCkEp2XlPB4PCL1QbhR75u2tOoG7qzcD/j6jQW0/jYxO/wvNQf/Y+CtHhnr/sLAPgy+8cozpsNAOHEgaZMJfJBUwg6BM6gCfGwX4YZNI/tdnM8oY/49ucCT998BuDOO3QnVYwb2cgll/8t/QVD+bCfQwAAAABJRU5ErkJggg==" alt="" className={sidebar.sidebarItemIcon} />
                <span className={sidebar.sidebarItemDesc}>Pages</span>
              </div>              
            </button>
            <button className={Button.button}>
              <div className={sidebar.itemWrapper}>
                <img src="data:image/png;base64,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" alt="" className={sidebar.sidebarItemIcon} />
                <span className={sidebar.sidebarItemDesc}>Messenger</span>
              </div>              
            </button>

            <div className={sidebar.title}>ShortCut</div>
            <div className={sidebar.shortCut}>
              <ul>
                <li>
                  <FontAwesomeIcon icon={faUserGroup}/>
                  <span className={sidebar.sidebarItemDesc}>User</span>
                </li>
                <li>
                  <FontAwesomeIcon icon={faImage}/>
                  <span className={sidebar.sidebarItemDesc}>Photo</span>
                </li>
                <li>
                  <FontAwesomeIcon icon={faShield}/>
                  <span className={sidebar.sidebarItemDesc}>Security</span>
                </li>
                <li>
                  <FontAwesomeIcon icon={faUserAstronaut}/>
                  <span className={sidebar.sidebarItemDesc}>Support</span>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
     
    </React.Fragment>
  );
}

export default Sidebar;
