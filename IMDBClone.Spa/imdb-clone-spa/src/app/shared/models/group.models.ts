export interface IIdentifiableModel {
    name?: string;
    description?: string;
  }
  
  export interface BreadcrumbItem{
    title: string;
    link?: string;
    icon?: string;
  }
  
  export class Group<TKey, TModel extends IIdentifiableModel>{
    key!: TKey;
    items!: TModel[];
  
    constructor(key: TKey) {
      this.key = key;
      this.items = [];
    }
  
    static by<TKey, TModel>(items: TModel[], keySelector: (value: TModel) => TKey): Group<TKey, TModel>[] {
      const groups: Group<TKey, TModel>[] = [];
      items.forEach(item => {
        let group = groups.find(group => group.key === keySelector(item));
        if (!group) {
          group = new Group(keySelector(item));
          groups.push(group);
        }
        group.items.push(item);
      });
      return groups;
    }
  }